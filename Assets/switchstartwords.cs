using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class switchstartwords : MonoBehaviour
{
    TextMeshProUGUI heading;
    public float delay;
    public string[] Inst;
    int i = 0;
    // Start is called before the first frame update
    void Awake()
    {
        heading = gameObject.GetComponent<TextMeshProUGUI>();
        InvokeRepeating("wordchange", delay, delay);
    }

    void wordchange()
    {
        heading.text = Inst[i];
        i++;
        if(i >= Inst.Length)
        {
            i = 0;
        }
    }
   
}
