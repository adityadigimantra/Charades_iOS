using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sounds AudioSources")]
    public AudioSource CorrectAnswerSound;
    public AudioSource WrongAnswerSound;
    public AudioSource FinalScoreSound;
    public AudioSource BeforCountDownSound;
    public AudioSource TimesUpPanelSound;

    [Header("Sounds Objects")]
    public GameObject circleOn;
    public GameObject circleOff;

    public GameObject Arb_circleOn;
    public GameObject Arb_circleOff;
    public GameObject[] AllAudioSource;

    public string currentLanguage;
    private void Start()
    {
        currentLanguage = PlayerPrefs.GetString("Language");
        if(currentLanguage=="English")
        {
            circleOn.SetActive(true);
            circleOff.SetActive(false);
        }
        else
        {
            Arb_circleOn.SetActive(true);
            Arb_circleOff.SetActive(false);
        }
        foreach(GameObject g in AllAudioSource)
        {
            g.SetActive(true);
        }
    }

    public void PlayCorrectAnswerSound()
    {
        CorrectAnswerSound.Play();
    }

    public void PlayWrongAnswerSound()
    {
        WrongAnswerSound.Play();
    }

    public void PlayFinalScoreSound()
    {
        FinalScoreSound.Play();
    }

    public void PlayBeforeCountDownSound()
    {
        BeforCountDownSound.Play();
    }

    public void PlayTimesUpSound()
    {
        TimesUpPanelSound.Play();
    }
    public void ToggleSoundONOff()
    {
     if(currentLanguage=="English")
        {
            if (circleOn.activeSelf)//Switching OFF
            {
                circleOn.SetActive(false);
                circleOff.SetActive(true);
                foreach (GameObject g in AllAudioSource)
                {
                    g.SetActive(false);
                }
            }
            else//Switching ON
            {
                circleOn.SetActive(true);
                circleOff.SetActive(false);
                foreach (GameObject g in AllAudioSource)
                {
                    g.SetActive(true);
                }
            }
        }
     else
        {
            if (Arb_circleOn.activeSelf)//Switching OFF
            {
                Arb_circleOn.SetActive(false);
                Arb_circleOff.SetActive(true);
                foreach (GameObject g in AllAudioSource)
                {
                    g.SetActive(false);
                }
            }
            else//Switching ON
            {
                Arb_circleOn.SetActive(true);
                Arb_circleOff.SetActive(false);
                foreach (GameObject g in AllAudioSource)
                {
                    g.SetActive(true);
                }
            }
        }
        
    }
}
