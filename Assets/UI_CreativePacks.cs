using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CreativePacks : MonoBehaviour
{
    M_Manager manager;
    public SpriteRenderer[] sprity;
    Vector2 touch_trail_locator;
    Vector2 touch_spot_locator;
    public bool fingertrail = true;
    Camera camera;
    bool Insta_Trail = true;
    GameObject clone;
    GameObject clone2;
    public GameObject Trail;
    public GameObject TouchSpot;
    int touchcount;
    Touch touch;

    [System.Serializable]
    public class KeyTransitions
    {
        public Color Normal;
        public Color Pressed;
    }
    public KeyTransitions Marimba;
    public KeyTransitions Xylophone;
    public KeyTransitions Vibraphone;
    KeyTransitions CurrentTransition;

    void Start()
    {


        CurrentTransition = Marimba;
        camera = Camera.main;
        if(PlayerPrefs.HasKey("trail"))
        {
            if(PlayerPrefs.GetInt("trail") == 0)
            {
                ToggleSpotTrail(true);
            }
            else if((PlayerPrefs.GetInt("trail") == 1))
            {
                ToggleSpotTrail(false);
            }
        }
    }
    void LateUpdate()
    {
        touchcount = Input.touchCount;
        if(fingertrail)
        {
            Finger_Trail();
        }
        else { Finger_Spot(); }
       
    }

    void Finger_Trail()
    {
        //Debug.Log("trail");
        if(touchcount >= 1 )
        {
            Touch trail_touch;// = Input.GetTouch(0) ;
            if (touchcount >= 2)
            {
                trail_touch = Input.GetTouch(touchcount - 1);
            }
            else { trail_touch = Input.GetTouch(0); }
            touch_trail_locator = camera.ScreenToWorldPoint(trail_touch.position);

            if (trail_touch.phase == TouchPhase.Moved && touchcount <= 1)
            {
                if (Insta_Trail)
                {
                    clone = Instantiate(Trail, touch_trail_locator, Quaternion.identity) as GameObject;
                    Insta_Trail = false;
                }


            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Insta_Trail = true;
                Destroy(clone);
            }
            clone.transform.position = touch_trail_locator;
        }
        

        


    }
    void Finger_Spot()
    {
        //Debug.Log("spot");
        if(touchcount >= 1)
        {
            Touch spot_touch = Input.GetTouch(touchcount - 1);
            touch_spot_locator = camera.ScreenToWorldPoint(spot_touch.position);

            if (spot_touch.phase == TouchPhase.Began && touchcount <= 1)
            {
                clone2 = Instantiate(TouchSpot, touch_spot_locator, Quaternion.identity) as GameObject;
            }
        }
        
    }

    public void ToggleSpotTrail(bool param)
    {
        fingertrail = param;
        if(param)
        {
            PlayerPrefs.SetInt("trail", 0);
        }
        else if(!param)
        {
            PlayerPrefs.SetInt("trail", 1);
        }
    }
}
