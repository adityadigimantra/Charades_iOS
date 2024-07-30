using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;



    public class UnityAds : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
    public static UnityAds instance;
        public string androidGameId;
        public string iOSGameId;
        public bool isTestingMode = true;
        string gameID;

        public string androidBannerAdsID;
        public string androidIntersitalAdsID;
        public string androidRewardedAdsID;

        public string iOSBannerAdsID;
        public string iOSIntersitalAdsID;
        public string iOSRewardedAdsID;

        string banneradUnitId;
        string interAdUnitId;
        string rewardedAdUnitId;

        BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

        private void Awake()
        {
            InitializeAds();
            if(instance==null)
            {
                instance = this;
            }
        }


        void InitializeAds()
        {
            if(Application.platform==RuntimePlatform.Android)
            {
               gameID = androidGameId;
            }
            else if(Application.platform==RuntimePlatform.IPhonePlayer)
            {
               gameID = iOSGameId
                ;
            }
            

            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(gameID, isTestingMode, this);
            }
            InitializeBannerAds();
            InitializeInterstialAds();
            IntializeRewardedAds();
        }

        public void OnInitializationComplete()
        {
            print("Ads Initialized");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            print("Ads failed to Initialized");
        }


        #region BannerAds
        public void InitializeBannerAds()
        {
           if(Application.platform==RuntimePlatform.Android)
           {
               banneradUnitId = androidBannerAdsID;
           
               Advertisement.Banner.SetPosition(bannerPosition);
               LoadBannerAds();
           }
           else if(Application.platform==RuntimePlatform.IPhonePlayer)
           {
               banneradUnitId = iOSBannerAdsID;
               Advertisement.Banner.SetPosition(bannerPosition);
               LoadBannerAds();
           }    
        }

        public void LoadBannerAds()
        {
            BannerLoadOptions options = new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerLoadError
            };

            Advertisement.Banner.Load(banneradUnitId, options);
        }

        void OnBannerLoaded()
        {
            print("Banner Loaded");
            ShowBannerAds();
        }

        void OnBannerLoadError(string error)
        {
            print("Banner Loading failed");
        }

        public void ShowBannerAds()
        {
            BannerOptions options = new BannerOptions
            {
                showCallback = OnBannerShow,
                clickCallback = OnBannerClicked,
                hideCallback = OnBannerHidden
            };
            Advertisement.Banner.Show(banneradUnitId, options);
        }

        void OnBannerShow()
        {

        }

        void OnBannerClicked()
        {

        }

        void OnBannerHidden()
        {

        }


        #endregion

        #region InterstialAds and Rewarded Ads

        public void InitializeInterstialAds()
        {

           if(Application.platform==RuntimePlatform.Android)
           {
               interAdUnitId = androidIntersitalAdsID;
               LoadInterstialAds();
           
           }
           else if(Application.platform==RuntimePlatform.IPhonePlayer)
           {
               interAdUnitId = iOSIntersitalAdsID;
               LoadInterstialAds();
           }

        }

        public void IntializeRewardedAds()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
               rewardedAdUnitId = androidRewardedAdsID;
               LoadRewardedAds();
            }
            else if(Application.platform==RuntimePlatform.IPhonePlayer)
            {
               rewardedAdUnitId = iOSRewardedAdsID;
               LoadRewardedAds();
            }
           
        }

        public void LoadInterstialAds()
        {
            print("Loading Interstitial");
            Advertisement.Load(interAdUnitId, this);
        }

        public void LoadRewardedAds()
        {
            print("Loading Rewarded Ads");
            Advertisement.Load(rewardedAdUnitId, this);
        }

        public void showInterstitialAds()
        {
            print("Showing Ads");
            Advertisement.Show(interAdUnitId, this);
        }

        public void ShowRewardedAds()
        {
            print("Showing Rewarded Ads");
            Advertisement.Show(rewardedAdUnitId, this);
        }


        public void OnUnityAdsAdLoaded(string placementId)
        {
            if (placementId.Equals(interAdUnitId))
            {
                print("Interstitial Ads Loaded");
            }
            if (placementId.Equals(rewardedAdUnitId))
            {
                print("Rewarded Ads Loaded");
            }

        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            if (placementId.Equals(interAdUnitId))
            {
                print("Interstitial Ads failed to  Loaded");
            }
            if (placementId.Equals(rewardedAdUnitId))
            {
                print("Rewarded Ads failed to Loaded");
            }
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            print("Ads Show failed");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            print("Ads Show Started");
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            print("Ads Show Clicked");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (placementId.Equals(interAdUnitId))
            {
                print("Interstitial Ads Shown Complete");
            }
            if (placementId.Equals(rewardedAdUnitId) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
            {
                print("Rewarded Ads Show Complete");
               
            }
        }

        #endregion
    }
