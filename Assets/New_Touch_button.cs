using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class New_Touch_button : MonoBehaviour
{
    //stuff to change universally for all keys from the master script
    public float pitch = 0.5f;
    public float Clip_num = 0;


    RectTransform rect;
    Camera camera;
    Animator anim;
    AudioSource audi;
    HapticTypes hapt;
    public enum Vib_Intensity { light, heavy, heavier}    
    public Vib_Intensity viber;
    public AudioClip [] Clip;
    public bool Vibrate;
    [HideInInspector]
    bool sound_available;
    bool prevent_repeat;
    public bool rt_id;
    public bool button;

    void Start()
    {
        viber = Vib_Intensity.light;
        switch (viber)
        {
            case Vib_Intensity.light:
                hapt = HapticTypes.LightImpact;
                break;
            case Vib_Intensity.heavy:
                hapt = HapticTypes.Selection;
                break;
            case Vib_Intensity.heavier:
                hapt = HapticTypes.MediumImpact;
                break;
        }
        camera = Camera.main;
        rect = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        audi.pitch = 1f;
    }

    void Update()
    {       
        int touchcount = Input.touchCount;       
        for (int i = 0; i < touchcount; i++)
        {
            Touch touch = Input.GetTouch(i);             
            if (RectTransformUtility.RectangleContainsScreenPoint(rect, touch.position, camera))
            {
                rt_id = true;
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved && touchcount <= 1)
                {
                    button = true;                  
                }
                else { button = false; }

                if(button)
                {
                    anim.SetBool("isplayed", true);
                    if (Clip[0] != null && sound_available)
                    {
                        audi.PlayOneShot(Clip[0]);
                        
                        sound_available = false;
                    }
                    if (Vibrate)
                    {
                        MMVibrationManager.Haptic(hapt);
                    }                  
                }
            }
            else { rt_id = false; }  
            
            if (touch.phase == TouchPhase.Ended || !rt_id && touch.tapCount <= 3)
            {
                sound_available = true;
                anim.SetBool("isplayed", false);
            }
            
        }
        

    }
    
}
