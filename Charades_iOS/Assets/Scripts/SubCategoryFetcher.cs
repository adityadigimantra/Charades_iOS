using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;


[System.Serializable]
public class subCategoryList
{
    public int id;
    public string name;
    public string arabic_name;
}

public class SubCategoryFetcher : MonoBehaviour
{
    public static SubCategoryFetcher instance;
    [Header("Making URL")]
    public string baseURL = "https://charades.foobar.in/api/sub_category/";
    public int categoryID;
    public string newURL;


    public List<subCategoryList> subCatLists = new List<subCategoryList>();

    private void Awake()
    {
       if(instance==null)
        {
            instance = this;

        }
    }


    public void makeSubCategoryURL()
    {
        categoryID = PlayerPrefs.GetInt("CategoryID");
        newURL = baseURL + categoryID;
        Debug.Log(newURL);
    }
    private void Update()
    { 
    }

     public  IEnumerator fetchSubCategories()
     {
        makeSubCategoryURL();

        using (UnityWebRequest www=UnityWebRequest.Get(newURL))
        {
            yield return www.SendWebRequest();
            if(!www.isHttpError && !www.isNetworkError)
            {
                string jsonData = www.downloadHandler.text;
                JSONNode jsonNode = JSON.Parse(jsonData);
                subCatLists.Clear();
                JSONNode dataArray = jsonNode["data"];
                for(int i=0;i<dataArray.Count;i++)
                {
                    subCategoryList categoryList = new subCategoryList();
                    categoryList.id = dataArray[i]["id"].AsInt;
                    categoryList.name = dataArray[i]["name"];
                    subCatLists.Add(categoryList);
                   
                }
                Debug.Log("SUB-Categories Data Updated");
                // GameManager.instance.getCategoryWords();

            }
            else
            {
                Debug.LogError("Failed to Fetch SubCategories" + www.error);
            }
        }
    }

}
