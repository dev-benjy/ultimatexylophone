using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Closer : MonoBehaviour
{
    Animator anim;
    public GameObject master;
    UI_CreativePacks packs;
    public M_Manager _Manager;
    public int Res;
    void Start()
    {
        
        anim = gameObject.GetComponentInParent<Animator>();
        packs = master.GetComponent<UI_CreativePacks>();;  
    }
    public void Activate_UI_Packs(bool param)
    {
        packs.enabled = param;
    }// disables ui fx trails and spots as and when needed.
    public void Activate_Keys(bool param)
    {
        if(param)
        {        
            _Manager.Mute = false;
        }
        else if(!param)
        {
            _Manager.Mute = true;//_Manager.DisableKeys();
        }
        Activate_UI_Packs(param);

    }//deactivates key sound by assign the key transforms as null. reassigning of transform when reactivated
    public void Open()
    {
        anim.SetBool("open", true);
    }
    public void Exit()
    {
        anim.SetBool("open", false);
    } 

}
