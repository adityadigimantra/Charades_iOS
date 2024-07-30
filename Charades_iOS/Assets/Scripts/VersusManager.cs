using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersusManager : MonoBehaviour
{
    [Header("Teams Objects")]
    public GameObject[] TeamsObject;
    [Header("Rounds Object")]
    public GameObject[] RoundsObject;
    public int teamSelectedValue;
    public int roundSelectedValue;
    public GameObject continueButton;
    public Animator versusAnimator;

    private void Start()
    {
        PlayerPrefs.SetInt("SelectedTeamsValue", 0);
        PlayerPrefs.SetInt("SelectedRoundValue", 0);
        gameObject.SetActive(true);
        versusAnimator.SetBool("isOpen", true);
        
    }
    private void Update()
    {
        Debug.Log("Selected Teams Value:" + PlayerPrefs.GetInt("SelectedTeamsValue"));
        Debug.Log("Selected Rounds Value:" + PlayerPrefs.GetInt("SelectedRoundValue"));
        DisableButtonUntilNoInput();
    }
    public void getTeamsValue(int i)
    {
        teamSelectedValue = i;
    }

    public void getRoundsValue(int i)
    {
        roundSelectedValue = i;
    }

    public void continueButtonPanel()
    {
        versusAnimator.SetBool("IsOpen", false);
        //FindObjectOfType<HomeManager>().ChangeQuickPlayTabValues();
        StartCoroutine(CloseThisPanel());
    }
    IEnumerator CloseThisPanel()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
        DeselectAllOptionInVersusPanel();
    }

    public void DisableButtonUntilNoInput()
    {
        int roundValue = PlayerPrefs.GetInt("SelectedRoundValue");
        int teamsValue = PlayerPrefs.GetInt("SelectedTeamsValue");

        if(roundValue!=0 && teamsValue!=0)
        {
            continueButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
    }
    public void DeselectAllOptionInVersusPanel()
    {

    }
    public void SelectingRounds()
    {
        switch(roundSelectedValue)
        {
            case 3:
                selected3rdRoundObject();
                PlayerPrefs.SetInt("SelectedRoundValue", 3);
                break;
            case 5:
                selected5thRoundObject();
                PlayerPrefs.SetInt("SelectedRoundValue", 5);
                break;
            case 7:
                selected7thRoundObject();
                PlayerPrefs.SetInt("SelectedRoundValue", 7);
                break;
        }
    }
    public void SelectingTeams()
    {
        switch (teamSelectedValue)
        {
            case 2:
                selected2ndTeamObject();
                PlayerPrefs.SetInt("SelectedTeamsValue", 2);
                break;

            case 3:
                selected3rdTeamObject();
                PlayerPrefs.SetInt("SelectedTeamsValue", 3);
                break;
            case 4:
                selected4thTeamObject();
                PlayerPrefs.SetInt("SelectedTeamsValue", 4);
                break;
        }

    }

    //Teams Data

    //4th Object
    void selected4thTeamObject()
    {
        for (int i = 0; i < TeamsObject.Length; i++)
        {
            TeamsObject[2].transform.GetChild(0).gameObject.SetActive(true);
            TeamsObject[2].transform.GetChild(1).gameObject.SetActive(true);
            TeamsObject[2].transform.GetChild(2).gameObject.SetActive(false);
        }
        deselected2ndTeamObject();
        deselected3rdTeamObject();
    }
    void deselected4thTeamObject()
    {
        for (int i = 0; i < TeamsObject.Length; i++)
        {
            TeamsObject[2].transform.GetChild(0).gameObject.SetActive(false);
            TeamsObject[2].transform.GetChild(1).gameObject.SetActive(false);
            TeamsObject[2].transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    //3rd Object
    void selected3rdTeamObject()
    {
        for (int i = 0; i < TeamsObject.Length; i++)
        {
            TeamsObject[1].transform.GetChild(0).gameObject.SetActive(true);
            TeamsObject[1].transform.GetChild(1).gameObject.SetActive(true);
            TeamsObject[1].transform.GetChild(2).gameObject.SetActive(false);
        }
        deselected2ndTeamObject();
        deselected4thTeamObject();
    }

    void deselected3rdTeamObject()
    {
        for (int i = 0; i < TeamsObject.Length; i++)
        {
            TeamsObject[1].transform.GetChild(0).gameObject.SetActive(false);
            TeamsObject[1].transform.GetChild(1).gameObject.SetActive(false);
            TeamsObject[1].transform.GetChild(2).gameObject.SetActive(true);
        }

    }

    //2nd Object
    void selected2ndTeamObject()
    {
        for (int i = 0; i < TeamsObject.Length; i++)
        {
            TeamsObject[0].transform.GetChild(0).gameObject.SetActive(true);
            TeamsObject[0].transform.GetChild(1).gameObject.SetActive(true);
            TeamsObject[0].transform.GetChild(2).gameObject.SetActive(false);
        }

        deselected3rdTeamObject();
        deselected4thTeamObject();
    }
    void deselected2ndTeamObject()
    {
        for (int i = 0; i < TeamsObject.Length; i++)
        {
            TeamsObject[0].transform.GetChild(0).gameObject.SetActive(false);
            TeamsObject[0].transform.GetChild(1).gameObject.SetActive(false);
            TeamsObject[0].transform.GetChild(2).gameObject.SetActive(true);
        }
    }




    //Round Data

    //7th Round Object
    void selected7thRoundObject()
    {
        for (int i = 0; i < RoundsObject.Length; i++)
        {
            RoundsObject[5].transform.GetChild(0).gameObject.SetActive(true);
            RoundsObject[5].transform.GetChild(1).gameObject.SetActive(true);
            RoundsObject[5].transform.GetChild(2).gameObject.SetActive(false);

        }
        deselected3rdRoundObject();
        deselected5thRoundObject();
    }

    void deselected7thRoundObject()
    {
        for (int i = 0; i < RoundsObject.Length; i++)
        {
            RoundsObject[5].transform.GetChild(0).gameObject.SetActive(false);
            RoundsObject[5].transform.GetChild(1).gameObject.SetActive(false);
            RoundsObject[5].transform.GetChild(2).gameObject.SetActive(true);

        }
    }


    //5th Round Object
    void selected5thRoundObject()
    {
        for (int i = 0; i < RoundsObject.Length; i++)
        {
            RoundsObject[3].transform.GetChild(0).gameObject.SetActive(true);
            RoundsObject[3].transform.GetChild(1).gameObject.SetActive(true);
            RoundsObject[3].transform.GetChild(2).gameObject.SetActive(false);
        }
        deselected3rdRoundObject();
        deselected7thRoundObject();
    }

    void deselected5thRoundObject()
    {
        for (int i = 0; i < RoundsObject.Length; i++)
        {
            RoundsObject[3].transform.GetChild(0).gameObject.SetActive(false);
            RoundsObject[3].transform.GetChild(1).gameObject.SetActive(false);
            RoundsObject[3].transform.GetChild(2).gameObject.SetActive(true);
        }
    }



    //3rd Round Object
    void selected3rdRoundObject()
    {
        for (int i = 0; i < RoundsObject.Length; i++)
        {
            RoundsObject[1].transform.GetChild(0).gameObject.SetActive(true);
            RoundsObject[1].transform.GetChild(1).gameObject.SetActive(true);
            RoundsObject[1].transform.GetChild(2).gameObject.SetActive(false);
        }
        deselected5thRoundObject();
        deselected7thRoundObject();
    }

    void deselected3rdRoundObject()
    {
        for (int i = 0; i < RoundsObject.Length; i++)
        {
            RoundsObject[1].transform.GetChild(0).gameObject.SetActive(false);
            RoundsObject[1].transform.GetChild(1).gameObject.SetActive(false);
            RoundsObject[1].transform.GetChild(2).gameObject.SetActive(true);
        }

    }

}
