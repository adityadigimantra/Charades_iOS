
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu instance;
    public Text low_single_correctAnswersGiven;
    public Text low_single_wrongAnswersGiven;
    public Text high_single_correctAnswersGiven;
    public Text high_single_wrongAnswersGiven;
    public Text low_group_correctAnswersGiven;
    public Text low_group_wrongAnswersGiven;
    public Text high_group_correctAnswersGiven;
    public Text high_group_wrongAnswersGiven;
    public Text low_winnerTeamText;
    public Text high_winnerTeamText;
    public GameObject low_singleQuickPlayGameOverItems;
    public GameObject low_groupVerusGameOverItems;
    public GameObject high_singleQuickPlayGameOverItems;
    public GameObject high_groupVerusGameOverItems;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
       
    }

    public void Single_GetCorrectWrongAnswerForTexts()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            int correctAnswer = GameManager.instance.Single_QuickPlay_CorrectAnswerGiven.Count;
            low_single_correctAnswersGiven.text = correctAnswer.ToString();

            int wrongAnswer = GameManager.instance.Single_QuickPlay_WrongAnswerGiven.Count;
            low_single_wrongAnswersGiven.text = wrongAnswer.ToString();
        }
        else
        {
            int correctAnswer = GameManager.instance.Single_QuickPlay_CorrectAnswerGiven.Count;
            high_single_correctAnswersGiven.text = correctAnswer.ToString();

            int wrongAnswer = GameManager.instance.Single_QuickPlay_WrongAnswerGiven.Count;
            high_single_wrongAnswersGiven.text = wrongAnswer.ToString();
        }


    }

    public void Group_GetCorrectWrongAnswerForTexts()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            string winner = PlayerPrefs.GetString("WinningTeam");
            low_winnerTeamText.text = "Winner : " + winner;
            int correct = 0;
            int wrong = 0;
            switch (winner)
            {
                case "Team 1":
                    correct = PlayerPrefs.GetInt("CorrectAnswerByTeam1");
                    wrong = PlayerPrefs.GetInt("WrongAnswerByTeam1");
                    low_group_correctAnswersGiven.text = correct.ToString();
                    low_group_wrongAnswersGiven.text = wrong.ToString();
                    break;

                case "Team 2":
                    correct = PlayerPrefs.GetInt("CorrectAnswerByTeam2");
                    wrong = PlayerPrefs.GetInt("WrongAnswerByTeam2");
                    low_group_correctAnswersGiven.text = correct.ToString();
                    low_group_wrongAnswersGiven.text = wrong.ToString();
                    break;

                case "Team 3":
                    correct = PlayerPrefs.GetInt("CorrectAnswerByTeam3");
                    wrong = PlayerPrefs.GetInt("WrongAnswerByTeam3");
                    low_group_correctAnswersGiven.text = correct.ToString();
                    low_group_wrongAnswersGiven.text = wrong.ToString();
                    break;

                case "Team 4":
                    correct = PlayerPrefs.GetInt("CorrectAnswerByTeam4");
                    wrong = PlayerPrefs.GetInt("WrongAnswerByTeam4");
                    low_group_correctAnswersGiven.text = correct.ToString();
                    low_group_wrongAnswersGiven.text = wrong.ToString();
                    break;
            }
        }
        else
        {
            string winner = PlayerPrefs.GetString("WinningTeam");
            high_winnerTeamText.text = "Winner : " + winner;
            int correct = 0;
            int wrong = 0;
            switch (winner)
            {
                case "Team 1":
                    correct = PlayerPrefs.GetInt("CorrectAnswerByTeam1");
                    wrong = PlayerPrefs.GetInt("WrongAnswerByTeam1");
                    high_group_correctAnswersGiven.text = correct.ToString();
                    high_group_wrongAnswersGiven.text = wrong.ToString();
                    break;

                case "Team 2":
                    correct = PlayerPrefs.GetInt("CorrectAnswerByTeam2");
                    wrong = PlayerPrefs.GetInt("WrongAnswerByTeam2");
                    high_group_correctAnswersGiven.text = correct.ToString();
                    high_group_wrongAnswersGiven.text = wrong.ToString();
                    break;

                case "Team 3":
                    correct = PlayerPrefs.GetInt("CorrectAnswerByTeam3");
                    wrong = PlayerPrefs.GetInt("WrongAnswerByTeam3");
                    high_group_correctAnswersGiven.text = correct.ToString();
                    high_group_wrongAnswersGiven.text = wrong.ToString();
                    break;

                case "Team 4":
                    correct = PlayerPrefs.GetInt("CorrectAnswerByTeam4");
                    wrong = PlayerPrefs.GetInt("WrongAnswerByTeam4");
                    high_group_correctAnswersGiven.text = correct.ToString();
                    high_group_wrongAnswersGiven.text = wrong.ToString();
                    break;
            }
        }
        
    }

    public void PlayThisDeckAgain()
    {
        GameManager.instance.CloseGameSections();
        // GameManager.instance.StartNewGame();
    }
    public void goBackToHome()
    {
        GameManager.instance.CloseGameSections();
    }
}



