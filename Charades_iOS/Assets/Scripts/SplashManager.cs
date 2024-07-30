
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class SplashManager : MonoBehaviour
{
    public static SplashManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    #region Prepare Home Screen
    public void PrepareHomeScreen()
    {
        StartCoroutine(prepareHomeScreen());
    }
    IEnumerator prepareHomeScreen()
    {
      yield return new WaitForSeconds(2f);
      LevelLoader.instance.StartLoadingTransition();
    }
  
    #endregion
}
