
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class SplashManager : MonoBehaviour
{
    public static SplashManager instance;
    public GameObject loadingObject;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    #region Prepare Home Screen
    public void prepareHomeScreen()
    {
        if(VersionControl.instance.versionUpToDate)
        {
            loadingObject.SetActive(true);
            LevelLoader.instance.StartLoadingTransition();
        }
    }
    #endregion
}
