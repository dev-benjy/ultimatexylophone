using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareApp : MonoBehaviour
{

    const string Address = "http://twitter.com/intent/tweet";

    public static void Share(string text, string url,
                             string related, string lang = "en")
    {
        Application.OpenURL(Address +
                            "?text=" + WWW.EscapeURL(text) +
                            "&amp;url=" + WWW.EscapeURL(url) +
                            "&amp;related=" + WWW.EscapeURL(related) +
                            "&amp;lang=" + WWW.EscapeURL(lang));
    }

    public void Share_App(int param)
    {
        if (param == 1)
        {
            Application.OpenURL("https://www.facebook.com/stories/create");
        }
        else if (param == 2)
        {
            Share("Check out this new app called Marimba Jam. It's pretty good!", "www.google.com","","en");
        }
        else if(param == 3)
        {
            Application.OpenURL("https://www.instagram.com/");
        }
        else { return; }
    }
    
    public void Enter_Web(string URL)
    {
        Application.OpenURL(URL);
    }
    



}
