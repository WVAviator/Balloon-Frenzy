using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;

public class MobileAds : MonoBehaviour {

    private InterstitialAd interstitial;
    private BannerView bv;
    bool adsEnabled = true;
    
    void Start()
    {
        if (PlayerManager.isPaidVersion) return;
        if(adsEnabled) LoadBanner();
    }

    public void ShowAd()
    {
        if (!adsEnabled) return;
        RequestInterstitial();
        ShowInterstitial();
    }

    public void ShowBanner()
    {
        if (!adsEnabled) return;
        bv.Show();
    }

    public void HideBanner()
    {
        bv.Hide();
    }

    public void DestroyAdInstances()
    {
        interstitial.Destroy();
        bv.Destroy();
        adsEnabled = false;
    }

    public void LoadBanner()
    {
        if (!adsEnabled) return;
        string adUnitId = "ca-app-pub-5063404247239757/3231337620";
        bv = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = createAdRequest();
        bv.LoadAd(request);
    }

    public void RequestInterstitial()
    {
        if (!adsEnabled) return;
        string adUnitId = "ca-app-pub-5063404247239757/4689881221";
        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
        // Register for ad events.
        interstitial.OnAdLoaded += HandleInterstitialLoaded;
        interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
        interstitial.OnAdOpening += HandleInterstitialOpened;
        interstitial.OnAdClosed += HandleInterstitialClosed;
        interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
        // Load an interstitial ad.
        interstitial.LoadAd(createAdRequest());
    }

    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder()
                .AddKeyword("game")
                .SetBirthday(new DateTime(1995, 1, 1))
                .TagForChildDirectedTreatment(false)
                .AddExtra("color_bg", "1196F3")
                .Build();
    }

    public void ShowInterstitial()
    {
        if (!adsEnabled) return;
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            print("Interstitial is not ready yet.");
        }
    }

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("HandleInterstitialLoaded event received.");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        print("HandleInterstitialOpened event received");
    }

    void HandleInterstitialClosing(object sender, EventArgs args)
    {
        print("HandleInterstitialClosing event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        print("HandleInterstitialClosed event received");       
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        print("HandleInterstitialLeftApplication event received");
    }

}
