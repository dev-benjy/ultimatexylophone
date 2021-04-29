using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;

public class Ad_Manage : MonoBehaviour
{
    //private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
       // if (interstitial != null)
        {
       //     interstitial .Destroy();
        }
        // Initialize an InterstitialAd.
      //  this.interstitial = new InterstitialAd(adUnitId);
        Load_Ad();
    }
    // Start is called before the first frame update
    void Start()
    {
        RequestInterstitial(); 
    }

    public void Load_Ad()
    {
        // Create an empty ad request.
      //  AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
       // this.interstitial.LoadAd(request);
    }

    public void Interstitial_Display()
    {
       // if (this.interstitial.IsLoaded())
        {
       //     this.interstitial.Show();
        }
        
    }
}
