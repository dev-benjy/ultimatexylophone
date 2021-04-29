using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class note_labeller : MonoBehaviour
{
    TextMeshPro lab_text;
    public string[] note_label;
    public M_Master master;
    M_Master.Pitch Pitch;
    string lab;
    private void Start()
    {       
        lab_text = gameObject.GetComponent<TextMeshPro>();
        lab = lab_text.text;
        Pitch = master.pitch;
        label_changer();
    }
    public void label_changer()
    {
       
        switch (Pitch.key_note)
        {
            case ("C"):
                lab_text.text = note_label[0];
                break;
            case ("C#"):
                lab_text.text = note_label[1];
                break;
            case ("D"):
                lab_text.text = note_label[2];
                break;
            case ("D#"):
                lab_text.text = note_label[3];
                break;
            case ("E"):
                lab_text.text = note_label[4];
                break;
            case ("F"):
                lab_text.text = note_label[5];
                break;
            case ("F#"):
                lab_text.text = note_label[6];
                break;
            case ("G"):
                lab_text.text = note_label[7];
                break;
            case ("G#"):
                lab_text.text = note_label[8];
                break;
            case ("A"):
                lab_text.text = note_label[9];
                break;
            case ("A#"):
                lab_text.text = note_label[10];
                break;
            case ("B"):
                lab_text.text = note_label[11];
                break;
            default:
                lab_text.text = note_label[0];
                break;
        }
    }

}
