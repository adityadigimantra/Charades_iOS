
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;

public class HomeManager : MonoBehaviour
{
    public static HomeManager instance;

    [Header("Game Modes_LowRes")]
    public GameObject quickPlayButton_selected;
    public GameObject quickPlayButton_Unselected;
    public GameObject teamsButton_Selected;
    public GameObject teamsButton_Unselected;

    [Header("Game Modes_HighRes")]
    public GameObject high_res_quickPlayButton_selected;
    public GameObject high_res_quickPlayButton_Unselected;
    public GameObject high_res_teamsButton_Selected;
    public GameObject high_res_teamsButton_Unselected;


    [Header("CategoriesDetails_Low/High")]
    public GameObject categoriesDetails_Panel;
    public Animator categoriesDetails_Animator;
    public GameObject high_res_categoriesDetails_Panel;
    public Animator high_res_categoriesDetails_Animator;

    [Header("UI-Panels_Low/High")]
    public GameObject versusPanel;
    public Animator versusPanelAnimator;
    public GameObject high_res_versusPanel;
    public Animator high_res_versusPanelAnimator;

    public GameObject loadingObj;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        StartCoroutine(SwitchOffLoadingObj());
        SelectQuickPlayMode();
    }
    void Update()
    {
        
        
    }

    public void SelectQuickPlayMode()
    {
        string playtype = "SingleQuickPlay";
        PlayerPrefs.SetString("GameType", playtype);
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            quickPlayButton_selected.SetActive(true);
            quickPlayButton_Unselected.SetActive(false);
            teamsButton_Unselected.SetActive(true);
            teamsButton_Selected.SetActive(false);
        }
        else
        {
            high_res_quickPlayButton_selected.SetActive(true);
            high_res_quickPlayButton_Unselected.SetActive(false);
            high_res_teamsButton_Unselected.SetActive(true);
            high_res_teamsButton_Selected.SetActive(false);
        }

    }

    public void SelectVSMode()
    {
        string playtype = "GroupVersus";
        PlayerPrefs.SetString("GameType", playtype);
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {

            teamsButton_Selected.SetActive(true);
            quickPlayButton_Unselected.SetActive(true);
            teamsButton_Unselected.SetActive(false);
            quickPlayButton_selected.SetActive(false);
            versusPanel.SetActive(true);
            versusPanelAnimator.SetBool("IsOpen", true);
        }
        else
        {
            high_res_teamsButton_Selected.SetActive(true);
            high_res_quickPlayButton_Unselected.SetActive(true);
            high_res_teamsButton_Unselected.SetActive(false);
            high_res_quickPlayButton_selected.SetActive(false);
            high_res_versusPanel.SetActive(true);
            high_res_versusPanelAnimator.SetBool("IsOpen", true);
        }

    }
    IEnumerator SwitchOffLoadingObj()
    {
        yield return new WaitForSeconds(1);
        loadingObj.SetActive(false);   
    }
}
