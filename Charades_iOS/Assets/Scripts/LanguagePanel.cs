using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguagePanel : MonoBehaviour
{
    private HomeManager hm;
    [Header("Language Panel")]
    public string ChoosenLanguage;
    public string currentLanguage;

    [Header("English Text Section")]
    public GameObject EnglishLanguagePanel;
    public GameObject EnglishTextBlue;
    public GameObject EnglishTextGray;
    public GameObject EnglishBlueCircle;
    public GameObject EnglishBackColorPanel;
    public Animator Eng_LanguageAnimator;

    [Header("Arabic Text")]
    public GameObject ArabicLanguagePanel;
    public GameObject ArabicTextBlue;
    public GameObject ArabicTextGray;
    public GameObject ArabicBlueCircle;
    public GameObject ArabicBackColorPanel;
    public Animator Arb_LanguageAnimator;




    // Start is called before the first frame update
    void Start()
    {
        hm = FindObjectOfType<HomeManager>();

        currentLanguage= PlayerPrefs.GetString("Language");
        Debug.Log("Current Language" + currentLanguage);
    }

    // Update is called once per frame
    void Update()
    {
        ChoosenLanguage = PlayerPrefs.GetString("Language");
        Debug.Log("Choosen Language"+ChoosenLanguage);
    }
    public void SelectEnglishLanguage()
    {
        //set Language to English

        //English Items Switches ON
        EnglishBlueCircle.SetActive(true);
        EnglishTextBlue.SetActive(true);
        EnglishTextGray.SetActive(false);
        EnglishBackColorPanel.SetActive(true);

        //Arabic Items Switches OFF
        ArabicTextBlue.SetActive(false);
        ArabicBlueCircle.SetActive(false);
        ArabicTextGray.SetActive(true);
        ArabicBackColorPanel.SetActive(false);
        ChoosenLanguage = "English";
        PlayerPrefs.SetString("Language", ChoosenLanguage);
    }
    public void SelectArabicLanguage()
    {
        //set Language as Arabic

        //Arabic Items Swtiches ON
        ArabicBlueCircle.SetActive(true);
        ArabicTextBlue.SetActive(true);
        ArabicTextGray.SetActive(false);
        ArabicBackColorPanel.SetActive(true);

        //English Items Switches OFF
        EnglishBlueCircle.SetActive(false);
        EnglishTextBlue.SetActive(false);
        EnglishTextGray.SetActive(true);
        EnglishBackColorPanel.SetActive(false);
        ChoosenLanguage = "Arabic";
        PlayerPrefs.SetString("Language", ChoosenLanguage);
    }
    public void SubmitButton()
    {
        if(ChoosenLanguage=="English" && currentLanguage=="Arabic" )
        {
            ArabicLanguagePanel.SetActive(false);
         
        }
        if(ChoosenLanguage=="Arabic" && currentLanguage=="English")
        {
           
            EnglishLanguagePanel.SetActive(false);

        }
        if(ChoosenLanguage=="English" && currentLanguage=="English")
        {
            Eng_LanguageAnimator.SetBool("isOpen", false);
            //EnglishLanguagePanel.SetActive(false);
        }
        if(ChoosenLanguage=="Arabic" && currentLanguage=="Arabic")
        {
            Arb_LanguageAnimator.SetBool("isOpen", false);
            //ArabicLanguagePanel.SetActive(false);
        }
    }



    
}
