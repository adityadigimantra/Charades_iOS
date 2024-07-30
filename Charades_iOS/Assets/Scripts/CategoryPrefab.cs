
//Welcome to the GameManager.cs
//This scripts handles all the gameplay mechanism
//There are public fields present of all the necessary elements
//This Game is Designed and Developed-
//Aditya Pandey
//Unity Developer



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPrefab : MonoBehaviour
{

    public int id;
    public int parent_id;
    public string name;
    public string arabic_name;
    public Texture2D imageTexture;
    public Texture2D arabicImage;
    public string description;
    public string arab_description;
    public int is_paid;
    public string price;
    public Button button;
    private void Update()
    {
        getButton();
        //checkIfObjIsInTheList();
    }

    public void getButton()
    {
        this.gameObject.name = name;
    }

    public void OnButtonClick()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            PlayerPrefs.SetString("CategorySelected", this.name);
            PlayerPrefs.SetInt("CategoryID", id);
            CategoriesDetial.instance.categoryID = id;
            Debug.Log("Category Selected" + gameObject.name + "with ID=" + PlayerPrefs.GetInt("CategoryID"));
            HomeManager.instance.categoriesDetails_Panel.SetActive(true);
            HomeManager.instance.categoriesDetails_Animator.SetBool("isOpen", true);
            //Fetching Sub-Categories
            StartCoroutine(SubCategoryFetcher.instance.fetchSubCategories());
            Texture tex = this.imageTexture;
            string str = this.description;
            string name = this.name;
            CategoriesDetial.instance.SetDetails(imageTexture, str, name);
        }
        else
        {
            PlayerPrefs.SetString("CategorySelected", this.name);
            PlayerPrefs.SetInt("CategoryID", id);
            CategoriesDetial.instance.categoryID = id;
            Debug.Log("Category Selected" + gameObject.name + "with ID=" + PlayerPrefs.GetInt("CategoryID"));
            HomeManager.instance.high_res_categoriesDetails_Panel.SetActive(true);
            HomeManager.instance.high_res_categoriesDetails_Animator.SetBool("isOpen", true);
            //Fetching Sub-Categories
            StartCoroutine(SubCategoryFetcher.instance.fetchSubCategories());
            Texture tex = this.imageTexture;
            string str = this.description;
            string name = this.name;
            CategoriesDetial.instance.SetDetails(imageTexture, str, name);
        }

    }
}
