using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToastNotificationSetter : MonoBehaviour
{
    public TextMeshProUGUI textmesh;
    Animator an;
    private void Start()
    {
        an = gameObject.GetComponent<Animator>();  
    }
    public void MusicToast()
    {
        SetText("Hold Button to Use, Or Change Settings");
    }
    public void DeveloperToast()
    {
        SetText("Under Construction, Check after updating: )");
    }
    public void NoInternetConnection()
    {
        SetText("Learn Mode error, No Internet?");
    }

    public void DisableToast()
    {
        gameObject.SetActive(false);
    }
    public void SetText(string text)
    {
        textmesh.text = text;
    }
}
