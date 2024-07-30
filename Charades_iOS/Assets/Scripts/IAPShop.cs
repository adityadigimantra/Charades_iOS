using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

[Serializable]
public class NonConsumableITem
{
    public string name;
    public string id;
    public string description;
    public int price;
    [Tooltip("1 is Not Purchased 2 is Purchased")]
    public int isPurchased = 0;
}


public class IAPShop : MonoBehaviour,IStoreListener
{
    IStoreController m_storeController;
    public NonConsumableITem ncITem;
    public GameObject Current_PaidPanel;
    public GameObject restoreButtonObj;
    public string selectedObjName;
    public Text titleText;
    [Header("Instances")]
    public GameManager gameManager;
    public CategoryPrefab categoryPrefab;

    // Start is called before the first frame update
    void Start()
    {
        checkForPlatformButton();
        SetupBuilder();
        gameManager = FindObjectOfType<GameManager>();
        categoryPrefab = FindObjectOfType<CategoryPrefab>();
        selectedObjName = PlayerPrefs.GetString("CategorySelected");
        //fixGUITextCS = FindObjectOfType<FixGUITextCS>();
        PutUpTextAndTitleOnUI();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PutUpTextAndTitleOnUI()
    {
        //string selectedLanguage = PlayerPrefs.GetString("Language");
        //if(selectedLanguage=="English")
        //{
        //    titleText.text = ncITem.name + " - " + ncITem.price;
        //}
        //else
        //{
        //    //fixGUITextCS.text= ncITem.name + " - " + ncITem.price;
        //    // titleText.text = fixGUITextCS.text;
        //}
        
    }    
    public void SetupBuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(ncITem.id, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this,builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        print("Success");
        m_storeController = controller;
    }

    public void OnPurchaseButtonPressed()
    {
        m_storeController.InitiatePurchase(ncITem.id);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;
        print("Purchase Completed" + product.definition.id);
        if (product.definition.id == ncITem.id)
        {
            //Gameobject to switch off.
            CheckforRecipt(ncITem.id);
           
        }
        return PurchaseProcessingResult.Complete;
    }

    private void checkForPlatformButton()
    {
        if(Application.platform!=RuntimePlatform.IPhonePlayer)
        {
            restoreButtonObj.SetActive(false);
        }
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Initailization failed" + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("Initailization failed" + error+message);
    }
    public void OnPurchaseFailed(Product product,PurchaseFailureReason failureReason)
    {
        print("Purchase Failed" + failureReason);
    }

    public void CheckforRecipt(string id)
    {
        if(m_storeController!=null)
        {
            var product = m_storeController.products.WithID(id);
            if(product!=null)
            {
                if(product.hasReceipt)
                {
                    //Unlock this category forever
                    //also Remove ads();
                    Current_PaidPanel.SetActive(false);
                    gameObject.SetActive(false);
                    ncITem.isPurchased = 2;
                    PlayerPrefs.SetInt(selectedObjName, 2); //2=Bought
                }    
                else
                {
                    //Continue showing ads
                }
            }
        }
    }
}
