using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CategoryManager : MonoBehaviour
{
    public static CategoryManager instance;

    [Header("GameObject Array")]
    public CategoryPrefab CategoryPrefab;
    public CategoryPrefab[] categoriesOBjs;
    public int CategoriesObjsLenght;

    [Header("Placements in Heirarchy-High/Low")]
    public GameObject categoryContent;
    public GameObject high_categoryContent;

    public bool canArrange = false;

    [Header("InputField Data")]
    public Text inputFieldText;
    public GameObject yourDecks_Content;

    public List<string> selectedYourDeckCategories = new List<string>();

    [Header("Device Resolutions")]
    private const int resHeight = 1920;
    private const int resWidth = 1080;
    public GameObject lowResUI;
    public GameObject highResUI;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        DetectResolution();
    }

    public void DetectResolution()
    {
        int currentScreenWidht = Screen.width;
        int currentScreenHeight = Screen.height;

        Debug.Log("Widht:" + currentScreenWidht + "Height:" + currentScreenHeight);

        if(currentScreenWidht>=resWidth || currentScreenHeight>=resHeight)
        {
            OpenHighResUI();
        }
        else
        {
            OpenLowResUI();
        }
    }

    private void Start()
    {
        CreateObj();
        loadYourDeckCategoriesList();

    }
    private void Update()
    {
        if (selectedYourDeckCategories.Count == 0)
        {
            selectedYourDeckCategories.Clear();
        }
        if(selectedYourDeckCategories.Count!=0)
        {
            arrangeCategories();
        }
        if(inputFieldText.text!=null)
        {
            findGameObject();
        }

    }

    public void OpenLowResUI()
    {
        PlayerPrefs.SetString("UIType", "lowRes");
        lowResUI.SetActive(true);
        if(highResUI.activeSelf)
        {
            highResUI.SetActive(false);
        }
    }

    public void OpenHighResUI()
    {
        PlayerPrefs.SetString("UIType", "highRes");
        highResUI.SetActive(true);
        if(lowResUI.activeSelf)
        {
            lowResUI.SetActive(false);
        }
    }


    public void CreateObj()
    {
        ConfigureLenghtOfArray();
        AssignDataToObj();
    }
    public void ConfigureLenghtOfArray()
    {
        CategoriesObjsLenght = CategoryFetcher.instance.categories.Count;
        categoriesOBjs = new CategoryPrefab[CategoriesObjsLenght];
    }

    public void AssignDataToObj()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            for (int i = 0; i < categoriesOBjs.Length; i++)
            {

                categoriesOBjs[i] = Instantiate(CategoryPrefab);
                categoriesOBjs[i].transform.position = categoryContent.transform.position;
                categoriesOBjs[i].transform.parent = categoryContent.transform;

                //Setting Data to Newly instatiated Data
                categoriesOBjs[i].id = CategoryFetcher.instance.categories[i].id;
                categoriesOBjs[i].parent_id = CategoryFetcher.instance.categories[i].parent_id;
                categoriesOBjs[i].name = CategoryFetcher.instance.categories[i].name;
                categoriesOBjs[i].arabic_name = CategoryFetcher.instance.categories[i].arabic_name;
                categoriesOBjs[i].description = CategoryFetcher.instance.categories[i].description;
                categoriesOBjs[i].arab_description = CategoryFetcher.instance.categories[i].arabic_description;
                categoriesOBjs[i].is_paid = CategoryFetcher.instance.categories[i].is_paid;
                categoriesOBjs[i].price = CategoryFetcher.instance.categories[i].price;
                categoriesOBjs[i].imageTexture = CategoryFetcher.instance.categories[i].imageTexture;
                categoriesOBjs[i].arabicImage = CategoryFetcher.instance.categories[i].arabicImageTexture;
                categoriesOBjs[i].GetComponent<RawImage>().texture = CategoryFetcher.instance.categories[i].imageTexture;
                categoriesOBjs[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                categoriesOBjs[i].gameObject.tag = "Main";
            }
        }
        else
        {
            for (int i = 0; i < categoriesOBjs.Length; i++)
            {

                categoriesOBjs[i] = Instantiate(CategoryPrefab);
                categoriesOBjs[i].transform.position = high_categoryContent.transform.position;
                categoriesOBjs[i].transform.parent = high_categoryContent.transform;

                //Setting Data to Newly instatiated Data
                categoriesOBjs[i].id = CategoryFetcher.instance.categories[i].id;
                categoriesOBjs[i].parent_id = CategoryFetcher.instance.categories[i].parent_id;
                categoriesOBjs[i].name = CategoryFetcher.instance.categories[i].name;
                categoriesOBjs[i].arabic_name = CategoryFetcher.instance.categories[i].arabic_name;
                categoriesOBjs[i].description = CategoryFetcher.instance.categories[i].description;
                categoriesOBjs[i].arab_description = CategoryFetcher.instance.categories[i].arabic_description;
                categoriesOBjs[i].is_paid = CategoryFetcher.instance.categories[i].is_paid;
                categoriesOBjs[i].price = CategoryFetcher.instance.categories[i].price;
                categoriesOBjs[i].imageTexture = CategoryFetcher.instance.categories[i].imageTexture;
                categoriesOBjs[i].arabicImage = CategoryFetcher.instance.categories[i].arabicImageTexture;
                categoriesOBjs[i].GetComponent<RawImage>().texture = CategoryFetcher.instance.categories[i].imageTexture;
                categoriesOBjs[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                categoriesOBjs[i].gameObject.tag = "Main";
            }
        }
        
    }

    public void arrangeCategories()
    {
        for(int i=0;i<selectedYourDeckCategories.Count;i++)
        {
            string targetName = selectedYourDeckCategories[i];
            GameObject targetObject = GameObject.Find(targetName);
            if(targetObject!=null)
            {
               targetObject.transform.SetSiblingIndex(i);
            }
            else
            {
                Debug.LogWarning("GameObject with name" + targetName + "Not found");
            }
        }
    }

    public void saveYourDeckCategoriesList()
    {
        string saveData = string.Join(";",selectedYourDeckCategories.ToArray());
        Debug.Log(saveData);
        PlayerPrefs.SetString("selectedYourDeckCategories", saveData);
        Debug.Log(PlayerPrefs.GetString("selectedYourDeckCategories"));
        //HomeManager.instance.yourDeckPanel.GetComponent<Animator>().SetBool("isOpen", false);
        //HomeManager.instance.closeYourDeckSection();
        arrangeCategories();
    }



    public void loadYourDeckCategoriesList()
    {
        if(PlayerPrefs.HasKey("selectedYourDeckCategories"))
        {
            string saveData = PlayerPrefs.GetString("selectedYourDeckCategories");
            selectedYourDeckCategories.AddRange(saveData.Split(';'));
        }
        if(selectedYourDeckCategories.Count!=0)
        {
            if (selectedYourDeckCategories[0] == "")
            {
                selectedYourDeckCategories.RemoveAt(0);
            }
        }
        
    }


    //Remove this Function (ONLY FOR TESTING)
    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void findGameObject()
    {
        string objName = inputFieldText.text;
        Transform transform = yourDecks_Content.transform.Find(objName);
        if(transform!=null)
        {
            GameObject foundObj = transform.gameObject;
            foundObj.transform.SetSiblingIndex(0);
        }
    }
}
