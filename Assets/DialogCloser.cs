using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCloser : MonoBehaviour
{
    Animator anim;
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        // _Manager = master.gameObject.GetComponent<M_Manager>();
    }
    public void Exit()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("exit", true);
        Invoke("INactive", 0.10f);

    } //invokes exit
    void INactive()
    {
        gameObject.SetActive(false);
    }//deactivates the UI Bar after the animation closes

}
