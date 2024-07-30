/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class AdMob : MonoBehaviour
{
    public string appID = "";

#if UNITY_ANDROID
    string interId = "";
    string bannerId = "";


#elif Unity_IPhone
    string interId = "";
    string bannerId = "";

#endif

    BannerView bannerView;
    InterstitialAd interstitialAd;

    private void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus =>
        {
            print("Ads Initialzed!");
        });
        LoadingBannerAds();
    }

    #region BannerAds
    public void LoadingBannerAds()
    {
        //create a banner.
        createBannerAds();
        //listen to banner events.
        ListenToBannerEvents();
        //load the banner
        if(bannerView==null)
        {
            createBannerAds();
        }
        var adrequest = new AdRequest();
        adrequest.Keywords.Add("unity_admob-sample");
        print("loading Banner ads!!");
        bannerView.LoadAd(adrequest);//Shows banner ad on the screen.
    }
    public void createBannerAds()
    {
        if(bannerView!=null)
        {
            DestroyBannerAds();
        }
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
    }

    public void ListenToBannerEvents()
    {
        /// <summary>
        /// listen to events the banner view may raise.
        /// </summary>
        // Raised when an ad is loaded into the banner view.
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
        
    }
    public void DestroyBannerAds()
    {
        if(bannerView!=null)
        {
            print("Destroying Banner Ad");
            bannerView.Destroy();
            bannerView = null;
        }
    }
    #endregion

    #region Interstial Ads
    public void LoadInterstialAds()
    {
        if(interstitialAd!=null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");
        InterstitialAd.Load(interId, adRequest, (InterstitialAd ad, LoadAdError error) =>
          {
              if (error != null || ad == null)
              {
                  print("Interstial Ads failed to load !!" + error);
                  return;
              }
              print("Interstial Ads Loaded !!"+ad.GetResponseInfo());
              interstitialAd = ad;
              InterstialEvents(interstitialAd);

          });
    }
    public void ShowInterstialAds()
    {
        if(interstitialAd!=null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            print("Interstial Ad is not ready !!");
        }
    }
    public void InterstialEvents(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }
    #endregion

    #region extra


    #endregion

    
}
*/
