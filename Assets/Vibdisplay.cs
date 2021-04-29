using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibdisplay : MonoBehaviour
{
    public Image[] image;
    public int NumberOfButtons;
    public int Selected;
    public Color Highlit;
    public bool default_black;
    public Color def_black;
    public void ButtonToToggleConvert(int param)
    {
        Selected = param;
        for(int i = 0; i < NumberOfButtons; ++i)
        {
            if(!default_black)
            {
                image[i].color = Color.white;
            }
            else if(default_black)
            {
                image[i].color = def_black;
            }
           
            
        }
        image[param].color = Highlit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
