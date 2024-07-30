using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Categories_PaidDetails : MonoBehaviour
{
    [Header("Details")]
    public RawImage imageTexture;
    public Text Eng_Description;
    public Text Arb_Description;
    public string selectedObjName;
    public GameObject selectedObj;
    public string selectedLanguage;
    public Text Category_buyText;
    public Text Alldeck_buyText;

    [Header("IAP Buttons")]
    public GameObject[] CategoryIAPButtons;

    [Header("Objects")]
    public GameObject thispanel;

    // Start is called before the first frame update
    void Start()
    {
        selectedLanguage = PlayerPrefs.GetString("Language");
    }

    public void getDetails()
    {
        selectedObjName = PlayerPrefs.GetString("CategorySelected");
        selectedObj = GameObject.Find(selectedObjName);

        imageTexture.texture = selectedObj.GetComponent<CategoryPrefab>().imageTexture;

        switch (selectedObjName)
            {
                case "Animals":
                    CategoryIAPButtons[4].SetActive(true);
                    break;
                case "Celebrities":
                    CategoryIAPButtons[0].SetActive(true);
                    break;
                case "Music":
                    CategoryIAPButtons[1].SetActive(true);
                    break;
                case "Countries":
                    CategoryIAPButtons[2].SetActive(true);
                    break;
                case "Fast Food":
                    CategoryIAPButtons[3].SetActive(true);
                    break;
                case "Cars":
                    CategoryIAPButtons[5].SetActive(true);
                    break;
            }
        if(selectedLanguage=="English")
        {
            Eng_Description.text = selectedObj.GetComponent<CategoryPrefab>().description;
        }
        else
        {
            Arb_Description.text= selectedObj.GetComponent<CategoryPrefab>().arab_description;
        }
    }
    public void closeThisPanel()
    {
        //Play Animation
        thispanel.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        getDetails();
    }

}
