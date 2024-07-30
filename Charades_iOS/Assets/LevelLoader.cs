using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public Animator transition;
    public float transitionTime = 1f;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    public void StartLoadingTransition()
    {
        StartCoroutine(startTransition());
    }
    IEnumerator startTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transition.SetTrigger("Start");
    }
}
