using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.SceneManagement;


[System.Serializable]
public class CategoryList
{
    public int id;
    public int parent_id;
    public string name;
    public string arabic_name;
    public string image;
    public string arabic_image;
    public string description;
    public string arabic_description;
    public int is_paid;
    public string price;
    public string created_at;
    public string updated_at;
    public string image_URL;
    public string arabic_image_url;
    public Texture2D imageTexture;
    public Texture2D arabicImageTexture;

}

public class CategoryFetcher : MonoBehaviour
{
    public static CategoryFetcher instance;
    public string categoryURL = "https://charades.foobar.in/api/category";
    public List<CategoryList> categories = new List<CategoryList>();
    public bool categoriesLoaded = false;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {

        StartFetchingCategories();
    }
    public void StartFetchingCategories()
    {
       StartCoroutine(fetchCategories());
    }

    public IEnumerator fetchCategories()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(categoryURL))
        {
            yield return www.SendWebRequest();
            if(!www.isNetworkError && !www.isHttpError)
            {
                string jsonData = www.downloadHandler.text;
                JSONNode jsonNode = JSON.Parse(jsonData);

                //clearing the old Categories List
                categories.Clear();

                //Parsing the Data and putting it in Categories List
                JSONNode dataArray = jsonNode["data"];
                for(int i=0;i<dataArray.Count;i++)
                {
                    CategoryList category = new CategoryList();
                    category.id = dataArray[i]["id"].AsInt;
                    category.parent_id = dataArray[i]["parent_id"].AsInt;
                    category.name = dataArray[i]["name"];
                    category.arabic_name = dataArray[i]["arabic_name"];
                    category.image = dataArray[i]["image"];
                    category.arabic_image = dataArray[i]["arabic_image"];
                    category.description = dataArray[i]["description"];
                    category.arabic_description = dataArray[i]["arabic_description"];
                    category.is_paid = dataArray[i]["is_paid"].AsInt;
                    category.price = dataArray[i]["price"];
                    category.created_at = dataArray[i]["created_at"];
                    category.updated_at = dataArray[i]["updated_at"];
                    category.image_URL = dataArray[i]["image_url"];
                    category.arabic_image_url = dataArray[i]["arabic_image_url"];

                    //loading textures from the URL
                    yield return loadTextureFromURL(category);
                    yield return loadArabicTextureFromURL(category);
                    categories.Add(category);

                }

                Debug.Log("Categories Data Updated");
                categoriesLoaded = true;
                SplashManager.instance.prepareHomeScreen();

            }
            else
            {
                Debug.LogError("Failed to fetch Categories;" + www.error);
                //retry fetching categories
                StartFetchingCategories();
            }
        }
    }

    IEnumerator loadTextureFromURL(CategoryList category)
    {
        using (UnityWebRequest www=UnityWebRequestTexture.GetTexture(category.image_URL))
        {
            yield return www.SendWebRequest();
            if(!www.isNetworkError && !www.isHttpError)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                category.imageTexture = texture;
            }
            else
            {
                Debug.LogError("Failed to fetch Textures:" + www.error);
                Debug.Log("Failed to load Image from URL" + category.image_URL);
            }
        }
    }
    IEnumerator loadArabicTextureFromURL(CategoryList category)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(category.arabic_image_url))
        {
            yield return www.SendWebRequest();
            if (!www.isHttpError && !www.isNetworkError)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                category.arabicImageTexture = texture;
            }
            else
            {
                Debug.Log("Failed to load Arabic image from URL" + category.arabic_image_url);
            }
        }
    }
}
