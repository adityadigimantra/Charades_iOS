using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VersionControl : MonoBehaviour
{
    public static VersionControl instance;
    public GameObject UpdatePanel;
    public GameObject LoadingPanel;
    public string LatestVersion, CurrentVersion;
    public bool versionUpToDate = false;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        StartCoroutine(CheckVersion());
    }
    void Start()
    {
        
    }

    public IEnumerator CheckVersion()
    {

        WWW BallGame = new WWW("https://raw.githubusercontent.com/adityadigimantra/Charades_VersionControl_iOS/main/Version%20Control");
        yield return new WaitUntil(() => BallGame.text != "");
        string lm = BallGame.text;
        LatestVersion = lm.Substring(0, lm.Length - 1);

        if (LatestVersion != CurrentVersion)
        {
            UpdatePanel.SetActive(true);
            versionUpToDate = false;
        }
        else
        {
            versionUpToDate = true;
        }
        yield break;

    }
    IEnumerator closeLoadingPanel()
    {
        yield return new WaitForSeconds(0.5f);
        LoadingPanel.SetActive(false);
    }
    IEnumerator loadAfterFewSeconds(float waitBySeconds)
    {
        yield return new WaitForSeconds(waitBySeconds);
        LevelLoader.instance.StartLoadingTransition();
    }
    public void ContinueButtonFunction()
    {
        UpdatePanel.SetActive(false);
        versionUpToDate = true;
        if (CategoryFetcher.instance.categoriesLoaded)
        {
            SplashManager.instance.prepareHomeScreen();
        }
        else
        {
            CategoryFetcher.instance.fetchCategories();
        }
    }
    public void UpdateGameFunction()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.digimantralabs.adventurerun3d");
    }

}
