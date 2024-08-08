using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VersionControl : MonoBehaviour
{
    public GameObject UpdatePanel;
    public GameObject LoadingPanel;
    public string LatestVersion, CurrentVersion;

    void Start()
    {
        StartCoroutine(CheckVersion());
    }

    IEnumerator CheckVersion()
    {

        WWW BallGame = new WWW("https://raw.githubusercontent.com/adityadigimantra/Charades_VersionControl_iOS/main/Version%20Control");
        yield return new WaitUntil(() => BallGame.text != "");
        string lm = BallGame.text;
        LatestVersion = lm.Substring(0, lm.Length - 1);

        if (LatestVersion != CurrentVersion)
        {
            UpdatePanel.SetActive(true);
            LoadingPanel.SetActive(false);
        }
        else
        {
            LoadingPanel.SetActive(true);
        }
        yield break;

    }

    IEnumerator loadAfterFewSeconds(float waitBySeconds)
    {
        yield return new WaitForSeconds(waitBySeconds);
        SceneManager.LoadScene(2);
    }
    public void ContinueButtonFunction()
    {
        UpdatePanel.SetActive(false);
        LoadingPanel.SetActive(true);
    }
    public void UpdateGameFunction()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.digimantralabs.adventurerun3d");
    }

}
