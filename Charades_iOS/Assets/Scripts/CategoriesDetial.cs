
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesDetial : MonoBehaviour
{
    public static CategoriesDetial instance;

    [Header("CategoryDetails-Low Resolution")]
    public GameObject low_categoriesDetials_Panel;
    public Animator low_categoriesDetails_Animatior;
    public RawImage low_imageTexture;
    public Text low_description_Text;
    public Text low_playModeType_Text;
    public GameObject low_likeButton;


    [Header("CategoryDetails-High Resolution")]
    public GameObject high_categoriesDetials_Panel;
    public Animator high_categoriesDetails_Animatior;
    public RawImage high_imageTexture;
    public Text high_description_Text;
    public Text high_playModeType_Text;
    public GameObject high_likeButton;



    public string selectedObjName;
    public GameObject selectedObj;
    public int oldSiblingIndex = -1;
    public bool isFirstSibling = false;
    public int categoryID;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }


    public void SetDetails(Texture tex, string des, string name)
    {

        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Low Res.
            low_imageTexture.texture = tex;
            low_description_Text.text = des;
            selectedObjName = name;
            PutPlayTypeDetails();
            FindSelectedGameObject();
            ActiDeactiRedHeartOfObj();
        }
        else
        {
            //High Res.
            high_imageTexture.texture = tex;
            high_description_Text.text = des;
            selectedObjName = name;
            PutPlayTypeDetails();
            FindSelectedGameObject();
            ActiDeactiRedHeartOfObj();
        }

    }
    public void PutPlayTypeDetails()
    {

        //Single QuickPlay
        if (PlayerPrefs.GetString("GameType") == "SingleQuickPlay")
        {
            if(PlayerPrefs.GetString("UIType")=="lowRes")
            {
                low_playModeType_Text.text = "Quick Play";
            }
            else
            {
                high_playModeType_Text.text = "Quick Play";
            }
           
        }

        //Group Teams
        if (PlayerPrefs.GetString("GameType") == "GroupVersus")
        {
           int selectedTeamValue = PlayerPrefs.GetInt("SelectedTeamsValue");
           int selectedRoundValue = PlayerPrefs.GetInt("SelectedRoundValue");

           if(PlayerPrefs.GetString("UIType")=="lowRes")
            {
                low_playModeType_Text.text = selectedTeamValue.ToString() + " Teams , " + selectedRoundValue.ToString() + " Rounds";
            }
           else
            {
                high_playModeType_Text.text = selectedTeamValue.ToString() + " Teams , " + selectedRoundValue.ToString() + " Rounds";
            }
           
        }

        
    }
    public void FindSelectedGameObject()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            Transform t = CategoryManager.instance.categoryContent.transform.Find(selectedObjName);
            selectedObj = t.gameObject;
        }
        else
        {
            Transform t = CategoryManager.instance.high_categoryContent.transform.Find(selectedObjName);
            selectedObj = t.gameObject;
        }
    }

    public void ActiDeactiRedHeartOfObj()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            if (gameObject.activeSelf)
            {
                if (selectedObj.transform.GetSiblingIndex() == 0)
                {
                    low_likeButton.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    low_likeButton.GetComponent<Image>().color = Color.grey;
                }
            }
        }
        else
        {
            if (gameObject.activeSelf)
            {
                if (selectedObj.transform.GetSiblingIndex() == 0)
                {
                    high_likeButton.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    high_likeButton.GetComponent<Image>().color = Color.grey;
                }
            }
        }

    }


    public void CloseCharadeDetailPanel()
    {
        gameObject.GetComponent<Animator>().SetBool("isOpen", false);
        StartCoroutine(closeCharadeDetailPanel());
    }
    IEnumerator closeCharadeDetailPanel()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().totalTime = 30;
        FindObjectOfType<GameManager>().timeRemaining = 30;
    }
    public void LikeButton()
    {
        if(!isFirstSibling)
        {
            oldSiblingIndex = selectedObj.transform.GetSiblingIndex();
            selectedObj.transform.SetAsFirstSibling();
            if(PlayerPrefs.GetString("UIType")=="lowRes")
            {
                low_likeButton.GetComponent<Image>().color = Color.red;
            }
            else
            {
                high_likeButton.GetComponent<Image>().color = Color.red;
            }
            isFirstSibling = true;
        }
        else
        {
            selectedObj.transform.SetSiblingIndex(oldSiblingIndex);
            if (PlayerPrefs.GetString("UIType") == "lowRes")
            {
                low_likeButton.GetComponent<Image>().color = Color.grey;
            }
            else
            {
                high_likeButton.GetComponent<Image>().color = Color.grey;
            }
                
            isFirstSibling = false;
        }
        /*
            if (CategoryManager.instance.selectedYourDeckCategories.Contains(selectedObjName))
            {
                CategoryManager.instance.selectedYourDeckCategories.Remove(selectedObjName);
               
            }
        
        string saveData = string.Join(";", CategoryManager.instance.selectedYourDeckCategories.ToArray());
        Debug.Log(saveData);
        PlayerPrefs.SetString("selectedYourDeckCategories", saveData);
        Debug.Log(PlayerPrefs.GetString("selectedYourDeckCategories"));
        */
    }
   


    public void CategoriesDetails_BackButton()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            low_categoriesDetails_Animatior.SetBool("isOpen", false);
        }
        else
        {
            high_categoriesDetails_Animatior.SetBool("isOpen", false);
        }
       
        foreach(CategoryPrefab g in CategoryManager.instance.categoriesOBjs)
        {
            g.gameObject.GetComponent<Button>().interactable = false;
        }
        StartCoroutine(CloseCategoriesDetailsPanel(0.5f));
    }


    IEnumerator CloseCategoriesDetailsPanel(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (PlayerPrefs.GetString("UIType") == "lowRes")
        {
            low_categoriesDetials_Panel.SetActive(false);
        }
        else
        {
            high_categoriesDetials_Panel.SetActive(false);
        }
           
        foreach (CategoryPrefab g in CategoryManager.instance.categoriesOBjs)
        {
            g.gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
