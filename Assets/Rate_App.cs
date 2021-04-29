using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rate_App : MonoBehaviour
{
    public float WaitAfterRate = 0.70f;
    public Image[] sprite = new Image[5];
    public GameObject bugreport;
    public GameObject rater;
    public GameObject setting;
    public DialogCloser close;
    public Animator anim;
    public Color grey;

    public void ResetRate()
    {
        for (int i = 0; i <= 4; i++)
        {
            sprite[i].color = grey;
        }
    }
    public void getRate(int star_index)
    {
        for (int i = 0; i <= star_index; i++)
        {
            sprite[i].color = Color.yellow;
        }
        if(star_index < 2)
        {
            anim.SetInteger("isliked", 2);
            Invoke("Bugger", WaitAfterRate);

        }
        else if(star_index >= 2)
        {
           
            anim.SetInteger("isliked", 1);
            Invoke("Call_AppstoreURL", WaitAfterRate);
        }
        else { return; }
    }
    void Call_AppstoreURL()
    {
        Application.OpenURL("market://details?id=com.soundandfury.saucillator");
        Israting();
        return;
    }
    void Bugger()
    {
        bugreport.SetActive(true);
        rater.SetActive(false);
    }
    void Israting()
    {
        close.Exit();
        setting.SetActive(true);
        rater.SetActive(false);
    }

}
