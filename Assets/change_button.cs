using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_button : MonoBehaviour
{
    Button button;
    M_Master zoomscript;
    Animator ani;
    public GameObject mas;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        zoomscript = mas.GetComponent<M_Master>();
        ani = gameObject.GetComponentInChildren<Animator>();
       // button.onClick.AddListener();
    }
    public void butoon_click()
    {
        if (zoomscript.joom)
        {
            ani.SetBool("flip", true);
        }
        else if(zoomscript.retrac)
        {
            ani.SetBool("flip", false);
        }
    }
 
}
