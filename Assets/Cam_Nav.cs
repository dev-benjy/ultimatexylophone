using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cam_Nav : MonoBehaviour
{
    //public Slider slider;
    Camera cam;
    Transform trans;
    int Res_Option;
    [System.Serializable]
    public class Res_Set
    {
        public Vector3 Default;
        public Vector3 Zoom;
        public Vector3 Magnify;
        public float Z_CamFocus;
        public float D_CamFocus;
        public float ZZ_CamFocus;
    }
    public Res_Set norm = new Res_Set();
    public Res_Set wide = new Res_Set();

    Vector3 Default;
    Vector3 Zoom;
    Vector3 Magnify;
    float Z_CamFocus;
    float D_CamFocus;
    float ZZ_CamFocus;

    float Max_AspectThreshold = 2.050f;
    float Min_AspectThreshold = 1.667f;
    float WideFocusDelta = 0f;
    float DefFocusDelta = 0f;

    bool Move1;
    bool Hold1;
    bool Move2;
    bool Hold2;
    public Animator button_anim;
    public float TimeDelta;
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        cam = Camera.main;
        // Beyond provided Wide Aspect Ratios
        if(cam.aspect >= Max_AspectThreshold)
        {
            Default = wide.Default;
            Zoom = wide.Zoom;
            Magnify = wide.Magnify;
            Z_CamFocus = wide.Z_CamFocus - WideFocusDelta;
            D_CamFocus = wide.D_CamFocus - WideFocusDelta;
            ZZ_CamFocus = wide.ZZ_CamFocus - WideFocusDelta;
        }
        //Beyond provided narrow aspect rtios
        else if(cam.aspect <= Min_AspectThreshold)
        {
            Default = norm.Default;
            Zoom = norm.Zoom;
            Magnify = norm.Magnify;
            Z_CamFocus = norm.Z_CamFocus + DefFocusDelta;
            D_CamFocus = norm.D_CamFocus + DefFocusDelta;
            ZZ_CamFocus = norm.ZZ_CamFocus + DefFocusDelta;
        }
        //standard aspect ratios
        else if(cam.aspect >= Min_AspectThreshold && cam.aspect <= Max_AspectThreshold)
        {
            if(cam.aspect <= Max_AspectThreshold && cam.aspect >= 1.9f)
            {
                Default = wide.Default;
                Zoom = wide.Zoom;
                Magnify = wide.Magnify;
                Z_CamFocus = wide.Z_CamFocus;
                D_CamFocus = wide.D_CamFocus;
                ZZ_CamFocus = wide.ZZ_CamFocus;
            }
            else if(cam.aspect >= Min_AspectThreshold && cam.aspect <= 1.9f)
            {
                Default = norm.Default;
                Zoom = norm.Zoom;
                Magnify = norm.Magnify;
                Z_CamFocus = norm.Z_CamFocus;
                D_CamFocus = norm.D_CamFocus;
                ZZ_CamFocus = norm.ZZ_CamFocus;
            }
        }
        cam.orthographicSize = D_CamFocus;
        trans.localPosition = Default;
    }

    public void movecamera(bool param)
    {
        Move1 = param;
        Hold1 = false;
        Move2 = false;
        if (Move1)
        {

            button_anim.SetBool("flip", true);
            cam.orthographicSize = Z_CamFocus;
            // cam.orthographicSize = Z_CamFocus;
            trans.localPosition = Zoom;
        }
        else if (!Move1 && !Hold1)
        {
            button_anim.SetBool("flip", false);
            cam.orthographicSize = D_CamFocus;
            trans.localPosition = Default;
        }

    }
    
    
    public void zoomcamera(bool param)
    {
        Move2 = param;
        Hold2 = false;
        
        //Move1 = false;
        if (Move2)
        {
            button_anim.SetBool("slide", true);            
            cam.orthographicSize = ZZ_CamFocus;
            trans.localPosition = Magnify;
            Debug.Log(Move2);

        }
        else if (!Move2 && !Hold2)
        {
            button_anim.SetBool("slide", false);
            cam.orthographicSize = D_CamFocus;
            trans.localPosition = Default;
        }

    }
 
}
