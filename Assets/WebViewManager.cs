using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebViewManager : MonoBehaviour
{
    public ToastNotificationSetter toaster;
    public M_Manager keys;
    public GameObject show_brwsr_button;
    public GameObject hide_button;
    UniWebView webview;
    bool hide_brws;
    float trans_time = 0.35f;
    bool Activate = false;
    // Start is called before the first frame update
    void Start()
    {
        webview = gameObject.GetComponent<UniWebView>();
        Terminate_Browser();
    }

    public void StartBrowser(string pagename)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            toaster.gameObject.SetActive(true);
            toaster.NoInternetConnection();
            return;
        }
        else
        {
            webview.enabled = true;
            webview.Hide();
            webview.Load(pagename);
            keys.Mute = true;
            // webview.SetShowSpinnerWhileLoading(true);
        }
    }
    
    public void ActivateBrowser(float time)
    {
        webview.Show(true, UniWebViewTransitionEdge.Left, trans_time);
        show_brwsr_button.SetActive(false);
        hide_button.SetActive(true);
        keys.Mute = true;
        Activate = true;

    }
    public void DeactivateBrowser(float time)
    {
        webview.Hide(true, UniWebViewTransitionEdge.Left, trans_time);
        show_brwsr_button.SetActive(true);
        hide_button.SetActive(false);
        keys.Mute = false;
        keys.WebViewRectChange(true);
        Activate = false;

    }
    public void Terminate_Browser()
    {
        keys.Mute = false;
        webview.enabled = false;
        show_brwsr_button.SetActive(false);
        keys.WebViewRectChange(false);
    }

}
