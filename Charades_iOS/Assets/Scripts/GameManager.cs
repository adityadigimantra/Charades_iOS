

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region #Public Fields and Instances
    [Header("Panels")]
    public GameObject low_Eng_CharadeDetails;
    public GameObject high_Eng_CharadeDetails;
    public GameObject low_gameSection;
    public GameObject high_gameSection;
    public Animator low_gameSection_animator;
    public Animator high_gameSection_animator;
    public GameObject low_GameOverPanel;
    public GameObject high_GameOverPanel;
    public Animator low_GameOverPanel_animator;
    public Animator high_GameOverPanel_animator;
    public GameObject low_ResetRoundPanel;
    public GameObject high_ResetRoundPanel;
    public Text low_resetRoundPanel_correctAnswers;
    public Text high_resetRoundPanel_correctAnswers;
    public Text low_resetRoundPanel_WrongAnswers;
    public Text high_resetRoundPanel_WrongAnswers;
    public Text low_RoundResultText;
    public Text high_RoundResultText;
    public GameObject low_Eng_PaidPanel;
    public GameObject high_Eng_PaidPanel;
    public GameObject low_countDownCreamPanel;
    public GameObject low_gameWhitePanel;
    public GameObject high_countDownCreamPanel;
    public GameObject high_gameWhitePanel;
    public GameObject low_NoWordAtResetRound;
    public GameObject high_NoWordAtResetRound;

    [Header("Group Panels-Low/High")]
    public GameObject low_Group_Team_CorrectAnswerPanel;
    public GameObject low_Group_Team_PassAnswerPanel;
    public GameObject high_Group_Team_CorrectAnswerPanel;
    public GameObject high_Group_Team_PassAnswerPanel;


    [Header("Single QuickPlay-High/Low")]
    public GameObject low_Single_QuickPlay_PassAnswerPanel;
    public GameObject low_Single_QuickPlay_CorrectAnswerPanel;
    public GameObject low_Single_QuickPlay_NoWordsFound;
    public GameObject high_Single_QuickPlay_NoWordsFound;
    public GameObject high_Single_QuickPlay_PassAnswerPanel;
    public GameObject high_Single_QuickPlay_CorrectAnswerPanel;

    [Header("Buttons-High/Low")]
    public GameObject low_Single_QuickPlay_CorrectAnswerButton;
    public GameObject low_Single_QuickPlay_WrongAnswerButton;
    public GameObject high_Single_QuickPlay_CorrectAnswerButton;
    public GameObject high_Single_QuickPlay_WrongAnswerButton;


    [Header("Timer Settings")]
    public float totalTime=30;
    public float timeRemaining;
    public float Maximumtime;
    public float Minimumtime;
    public bool isCounting = true;
    public Text low_timeText;
    public Text high_timeText;

    [Header("Word Lists")]
    public List<string> WordList = new List<string>();
    public List<string> shownWords = new List<string>();
    public List<string> Group_QuickPlay_CorrectAnswerGiven = new List<string>();
    public List<string> Group_QuickPlay_WrongAnswerGiven = new List<string>();
    public List<string> Single_QuickPlay_WrongAnswerGiven = new List<string>();
    public List<string> Single_QuickPlay_CorrectAnswerGiven = new List<string>();
    public List<string> ResetRoundCorrectAnswerList = new List<string>();
    public List<string> ResetRoundWrongAnswerList = new List<string>();

    public int correctAnswerGivenCount;
    public int wrongAnswerGivenCount;

    [Header("Words")]
    public string nextWord;
    public string currentWord;
    public string previousWord;
    public int shownwordmaxSize;

    [Header("Instances")]
    public SubCategoryFetcher SubcategoryFetcher;
    public RecordManager recordManager;
    public CameraRecording cameraRecording;
    public SoundManager soundManager;
    public bool correctAnswer = false;
    public int rightAnswerGiven = 0;
    public int currentWordIndex = 0;

    [Header("Prefab")]
    public GameObject GO_Words;
    public GameObject[] goWords;
    public GameObject ResetRound_Word;

    public GameObject[] ResetRound_Words;



    [Header("General Data")]
    public bool roundEnded = false;
    public int currentMatch = 0;
    public int selectedTeamValue;
    public int selectedRoundValue;
    public int currentTeam;
    public int currentRound;
    [SerializeField]
    public Dictionary<string, List<string>> teams = new Dictionary<string, List<string>>();
    public List<string> CorrectAnswerGivenByTeams = new List<string>();
    public GameObject selectedObj;
    public string selectedObjName;


    #region Game Fields

    [Header("Team Section-Low Resolution")]
    public GameObject low_groupSection;
    public GameObject low_Group_TeamsSection;
    public GameObject low_Group_Team_Eng_CountDownItemsPanel;
    public GameObject[] low_Group_Team_Eng_CountDownItems;
    public GameObject low_Group_Team_CloseButton;
    public Text low_Group_Team_Eng_GameTimeText;
    public Text low_Group_Team_WordText;
    public Text low_Group_Team_Eng_SettingData;

    [Header("Team Section-High Resolution")]
    public GameObject high_groupSection;
    public GameObject high_Group_TeamsSection;
    public GameObject high_Group_Team_Eng_CountDownItemsPanel;
    public GameObject[] high_Group_Team_Eng_CountDownItems;
    public GameObject high_Group_Team_CloseButton;
    public Text high_Group_Team_Eng_GameTimeText;
    public Text high_Group_Team_WordText;
    public Text high_Group_Team_Eng_SettingData;


    [Header("SingleSection-Low Resolution")]
    public GameObject low_singleSection;
    public GameObject low_Single_QuickPlaySection;
    public GameObject low_Single_QuickPlay_Eng_CountDownItemsPanel;
    public GameObject[] low_Single_QuickPlay_Eng_CountDownItems;
    public GameObject low_Single_QuickPlay_CloseButton;
    public Text low_Single_QuickPlay_Eng_GameTimeText;
    public Text low_Single_QuickPlay_WordText;

    [Header("SingleSection-High Resolution")]
    public GameObject high_singleSection;
    public GameObject high_Single_QuickPlaySection;
    public GameObject high_Single_QuickPlay_Eng_CountDownItemsPanel;
    public GameObject[] high_Single_QuickPlay_Eng_CountDownItems;
    public GameObject high_Single_QuickPlay_CloseButton;
    public Text high_Single_QuickPlay_Eng_GameTimeText;
    public Text high_Single_QuickPlay_WordText;

    #region Temporary List and public fields

    [Header("Temporary Teams List_CorrectAnswers")]
    public List<string> Temp_TeamList1 = new List<string>();
    public List<string> Temp_TeamList2 = new List<string>();
    public List<string> Temp_TeamList3 = new List<string>();
    public List<string> Temp_TeamList4 = new List<string>();

    [Header("Temporary Teams List_WrongAnswers")]
    public List<string> Temp_TeamList1_Wrong = new List<string>();
    public List<string> Temp_TeamList2_Wrong = new List<string>();
    public List<string> Temp_TeamList3_Wrong = new List<string>();
    public List<string> Temp_TeamList4_Wrong = new List<string>();


    [Header("Correct Answer Value of Team 1 in Rounds")]
    public int correctAnswerGivenT1R1 = 0;
    public int correctAnswerGivenT1R2 = 0;
    public int correctAnswerGivenT1R3 = 0;
    public int correctAnswerGivenT1R4 = 0;
    public int correctAnswerGivenT1R5 = 0;
    public int correctAnswerGivenT1R6 = 0;
    public int correctAnswerGivenT1R7 = 0;

    [Header("Wrong Answer Value of Team 1 in Rounds")]
    public int wrongAnswerGivenT1R1 = 0;
    public int wrongAnswerGivenT1R2 = 0;
    public int wrongAnswerGivenT1R3 = 0;
    public int wrongAnswerGivenT1R4 = 0;
    public int wrongAnswerGivenT1R5 = 0;
    public int wrongAnswerGivenT1R6 = 0;
    public int wrongAnswerGivenT1R7 = 0;


    [Header("Correct Answer Value of Team 2 in Rounds")]
    public int correctAnswerGivenT2R1 = 0;
    public int correctAnswerGivenT2R2 = 0;
    public int correctAnswerGivenT2R3 = 0;
    public int correctAnswerGivenT2R4 = 0;
    public int correctAnswerGivenT2R5 = 0;
    public int correctAnswerGivenT2R6 = 0;
    public int correctAnswerGivenT2R7 = 0;

    [Header("Wrong Answer Value of Team 2 in Rounds")]
    public int wrongAnswerGivenT2R1 = 0;
    public int wrongAnswerGivenT2R2 = 0;
    public int wrongAnswerGivenT2R3 = 0;
    public int wrongAnswerGivenT2R4 = 0;
    public int wrongAnswerGivenT2R5 = 0;
    public int wrongAnswerGivenT2R6 = 0;
    public int wrongAnswerGivenT2R7 = 0;



    [Header("Correct Answer Value of Team 3 in Rounds")]
    public int correctAnswerGivenT3R1 = 0;
    public int correctAnswerGivenT3R2 = 0;
    public int correctAnswerGivenT3R3 = 0;
    public int correctAnswerGivenT3R4 = 0;
    public int correctAnswerGivenT3R5 = 0;
    public int correctAnswerGivenT3R6 = 0;
    public int correctAnswerGivenT3R7 = 0;

    [Header("Wrong Answer Value of Team 3 in Rounds")]
    public int wrongAnswerGivenT3R1 = 0;
    public int wrongAnswerGivenT3R2 = 0;
    public int wrongAnswerGivenT3R3 = 0;
    public int wrongAnswerGivenT3R4 = 0;
    public int wrongAnswerGivenT3R5 = 0;
    public int wrongAnswerGivenT3R6 = 0;
    public int wrongAnswerGivenT3R7 = 0;

    [Header("Correct Answer Value of Team 4 in Rounds")]
    public int correctAnswerGivenT4R1 = 0;
    public int correctAnswerGivenT4R2 = 0;
    public int correctAnswerGivenT4R3 = 0;
    public int correctAnswerGivenT4R4 = 0;
    public int correctAnswerGivenT4R5 = 0;
    public int correctAnswerGivenT4R6 = 0;
    public int correctAnswerGivenT4R7 = 0;

    [Header("Wrong Answer Value of Team 4 in Rounds")]
    public int wrongAnswerGivenT4R1 = 0;
    public int wrongAnswerGivenT4R2 = 0;
    public int wrongAnswerGivenT4R3 = 0;
    public int wrongAnswerGivenT4R4 = 0;
    public int wrongAnswerGivenT4R5 = 0;
    public int wrongAnswerGivenT4R6 = 0;
    public int wrongAnswerGivenT4R7 = 0;

    [Header("TotalScores")]
    public int TotalScoreByTeam1;
    public int TotalScoreByTeam2;
    public int TotalScoreByTeam3;
    public int TotalScoreByTeam4;

    #endregion


    #endregion




    [Header("Score Details-LowRes")]
    public int score;
    public bool isScoreDetailOpened = false;
    public bool canCloseWinnerTag = false;
    public GameObject[] low_roundsObjs;
    public GameObject low_ScoreContents;
    public GameObject low_Group_Team_ScoreCardPanel;
    public Text low_FinalScoreText;
    public Text low_WinnerTeamText;

    [Header("Score Details-High Resolutions")]
    public GameObject[] high_roundsObjs;
    public GameObject high_ScoreContents;
    public GameObject high_Group_Team_ScoreCardPanel;
    public Text high_FinalScoreText;
    public Text high_WinnerTeamText;



    public GameObject TeamPrefab;

    [Header("CurrentTeamData")]
    public string CurrentTeamPlaying;

    #region Tilt/Screen Rotations

    [Header("Tilt")]
    public float tiltThreshold;
    public Text DeltaYText;
    private bool isPhoneHorizontal = false;
    public UnityEvent OnCorrectTilt;
    public UnityEvent OnWrongTilt;
    private bool correctTiltDetected = false;
    private bool isNeutral = false;
    private bool wrongTiltDetected = false;
    public float Hysteresis;
    public bool Isphonecorrected = false;
    public bool functionInvoked = false;
    [Header("Never Sleep")]
    public float screenLockDelay = 900;
    private float screenLockTimer;
    private bool isCorrectTiltInvoked = false;
    private bool isWrongTiltInvoked = false;
    public bool canShowNextWord = false;
    public bool correctImageShown = false;
    public bool lastWordSaved = true;
    public bool callingonce = false;

    #endregion

    public Text CorrectAnswerGivenInRoundResultText;
    private bool isTilted = false;

    public enum TiltState { NotTilted, Tilted };
    public TiltState currentTitleState = TiltState.NotTilted;

    #endregion

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        timeRemaining = totalTime;
        UpdateTimerText();
        SubcategoryFetcher = FindObjectOfType<SubCategoryFetcher>();
        soundManager = FindObjectOfType<SoundManager>();
        Input.gyro.enabled = true;
        PlayerPrefs.SetInt("GameStarted", 0);

        //if(PlayerPrefs.GetString("UIType")=="lowRes")
        //{
        //    low_Teams_HoldPhoneRightText.SetActive(false);
        //}
        //else
        //{
        //    high_Teams_HoldPhoneRightText.SetActive(false);
        //}

    }

    public void NeverSleepFunction()
    {
        if (Application.isPlaying && Time.time - screenLockTimer > screenLockDelay)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            screenLockTimer = Time.time;
        }
    }

    public void getCategoryDetails()
    {
        selectedObjName = PlayerPrefs.GetString("CategorySelected");
        selectedObj = GameObject.Find(selectedObjName);
    }


    public void StartNewGame()
    {
        if(selectedObj.GetComponent<CategoryPrefab>().is_paid==1) //If the category is Paid.
        {
            if(PlayerPrefs.GetInt(selectedObjName)==2) //If the category has been already purchased.
            {
                if(PlayerPrefs.GetString("GameType")=="GroupVersus")
                {
                    //Responsible for starting game for Group Versus.
                    if(PlayerPrefs.GetString("UIType")=="lowRes")
                    {
                        low_gameSection.SetActive(true);
                        low_gameSection_animator.SetBool("IsOpen", true);
                        low_groupSection.SetActive(true);
                        low_Group_TeamsSection.SetActive(true);
                        Group_TeamGameplayDesign();
                    }
                    else
                    {
                        high_gameSection.SetActive(true);
                        high_gameSection_animator.SetBool("IsOpen", true);
                        high_groupSection.SetActive(true);
                        high_Group_TeamsSection.SetActive(true);
                        Group_TeamGameplayDesign();
                    }
                    
                    
                }
                if (PlayerPrefs.GetString("GameType") == "SingleQuickPlay")
                {
                    //Responsible for starting game for Single QuickPlay.
                    if (PlayerPrefs.GetString("UIType") == "lowRes")
                    {
                        low_gameSection.SetActive(true);
                        low_gameSection_animator.SetBool("IsOpen", true);
                        low_singleSection.SetActive(true);
                        low_Single_QuickPlaySection.SetActive(true);
                        Single_QuickPlayDesign();
                    }
                    else
                    {
                        //High Res
                        high_gameSection.SetActive(true);
                        high_gameSection_animator.SetBool("IsOpen", true);
                        high_singleSection.SetActive(true);
                        high_Single_QuickPlaySection.SetActive(true);

                        Single_QuickPlayDesign();
                    }
                }
                StartCoroutine(CloseCharadeDetailAfterFewSec());
            }
            else //If the category is Paid and not purchased by Player.
            {
                if(PlayerPrefs.GetString("UIType")=="lowRes")
                {
                    low_Eng_PaidPanel.SetActive(true);
                }
                else
                {
                    high_Eng_PaidPanel.SetActive(true);
                }
              
            }
            
        }
        else //If the category is free already.
        {
            if(PlayerPrefs.GetString("UIType")=="lowRes")
            {
                //Low Res UI
                if (PlayerPrefs.GetString("GameType") == "GroupVersus")
                {
                    //Responsible for starting game for Group Versus.

                    low_gameSection.SetActive(true);
                    low_gameSection_animator.SetBool("IsOpen", true);
                    low_groupSection.SetActive(true);
                    low_Group_TeamsSection.SetActive(true);

                    Group_TeamGameplayDesign();
                }
                if (PlayerPrefs.GetString("GameType") == "SingleQuickPlay")
                {
                    //Responsible for starting game for Single QuickPlay.
                    low_gameSection.SetActive(true);
                    low_gameSection_animator.SetBool("IsOpen", true);
                    low_singleSection.SetActive(true);
                    low_Single_QuickPlaySection.SetActive(true);

                    Single_QuickPlayDesign();
                }
                StartCoroutine(CloseCharadeDetailAfterFewSec());
            }
            else
            {
                //High Res UI
                if (PlayerPrefs.GetString("GameType") == "GroupVersus")
                {
                    //Responsible for starting game for Group Versus.

                    high_gameSection.SetActive(true);
                    high_gameSection_animator.SetBool("IsOpen", true);
                    high_groupSection.SetActive(true);
                    high_Group_TeamsSection.SetActive(true);

                    Group_TeamGameplayDesign();
                }
                if (PlayerPrefs.GetString("GameType") == "SingleQuickPlay")
                {
                    //Responsible for starting game for Single QuickPlay.
                    high_gameSection.SetActive(true);
                    high_gameSection_animator.SetBool("IsOpen", true);
                    high_singleSection.SetActive(true);
                    high_Single_QuickPlaySection.SetActive(true);

                    Single_QuickPlayDesign();
                }

                StartCoroutine(CloseCharadeDetailAfterFewSec());

            }



        }

    }

    private void Update()
    {
        getCategoryDetails();
        NeverSleepFunction();
        CalculateTimeInUpdate();
        goWords = GameObject.FindGameObjectsWithTag("GoWords");
        ResetRound_Words = GameObject.FindGameObjectsWithTag("ResetRounds");
        //rightAnswerGiven = CorrectAnswerGiven.Count;
        //FinalScoreText.text = rightAnswerGiven.ToString();
        if (selectedTeamValue != 0)
        {
            currentTeam = currentMatch % selectedTeamValue + 1;
            Debug.Log("Current Team Playing" + currentTeam);
            currentRound = currentMatch / selectedTeamValue + 1;
        }
        string teamName = "Team" + currentTeam;
        ShowDataStoredInDictionaryTeams(teamName);
        getRoundWiseLenghtOfTeamsAnswers();

        //Checking if the list first element is null
        if (Group_QuickPlay_CorrectAnswerGiven.Count > 0 && Group_QuickPlay_CorrectAnswerGiven[0] == "")
        {
            Group_QuickPlay_CorrectAnswerGiven.RemoveAt(0);
        }
        if (Group_QuickPlay_WrongAnswerGiven.Count > 0 && Group_QuickPlay_WrongAnswerGiven[0] == "")
        {
            Group_QuickPlay_WrongAnswerGiven.RemoveAt(0);
        }
    }

    private void FixedUpdate()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            if (PlayerPrefs.GetString("GameType") == "GroupVersus")
            {
                Debug.Log("Coming this Way");
                if (PlayerPrefs.GetInt("GameStarted") == 1)
                {
                    tiltController();
                    //if (Input.acceleration.z >= 0.5f)
                    //{
                    //    low_Teams_HoldPhoneRightText.SetActive(true);
                    //}
                    //else if (Input.acceleration.z <= -0.5)
                    //{
                    //    low_Teams_HoldPhoneRightText.SetActive(true);
                    //}
                    //else
                    //{
                    //    low_Teams_HoldPhoneRightText.SetActive(false);
                    //}
                }
            }
            shownwordmaxSize = shownWords.Count;
        }
        else
        {
            if (PlayerPrefs.GetString("GameType") == "GroupVersus")
            {
                Debug.Log("Coming this Way");
                if (PlayerPrefs.GetInt("GameStarted") == 1)
                {
                    tiltController();
                    //if (Input.acceleration.z >= 0.5f)
                    //{
                    //    high_Teams_HoldPhoneRightText.SetActive(true);
                    //}
                    //else if (Input.acceleration.z <= -0.5)
                    //{
                    //    high_Teams_HoldPhoneRightText.SetActive(true);
                    //}
                    //else
                    //{
                    //    high_Teams_HoldPhoneRightText.SetActive(false);
                    //}
                }
            }
            shownwordmaxSize = shownWords.Count;
        }
        
    }

    public void tiltController()
    {
        //DeltaYText.text = Input.acceleration.z.ToString();
        switch (currentTitleState)
        {
            case TiltState.NotTilted:
                if (Input.acceleration.z >= (tiltThreshold + Hysteresis))
                {
                    currentTitleState = TiltState.Tilted;
                    OnCorrectTilt.Invoke();
                }
                if (Input.acceleration.z <= (-tiltThreshold - Hysteresis))
                {
                    currentTitleState = TiltState.Tilted;
                    OnWrongTilt.Invoke();
                }
                break;
            case TiltState.Tilted:
                break;
        }

        if (Input.acceleration.z >= -0.2 && Input.acceleration.z <= 0.2)
        {
            lastWordSaved = true;
            correctImageShown = false;
            currentTitleState = TiltState.NotTilted;
        }
    }

    IEnumerator GivePause()
    {
        yield return new WaitForSeconds(0.3f);
        correctTiltDetected = false;
        wrongTiltDetected = false;
    }


    public void CalculateTimeInUpdate()
    {
        #region MainGame Time
        if (isCounting)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0f)
            {
                //Timer Ends
                timeRemaining = 0f;
                isCounting = false;

                if(PlayerPrefs.GetString("GameType")=="GroupVersus")
                {
                    //Handles round reset for Group Versus.
                    Group_Team_ResetRound();
                }
                if (PlayerPrefs.GetString("GameType") == "SingleQuickPlay")
                {
                    //Handles round reset for Single QuickPlay.
                    Single_QuickPlay_ResetRound();
                }
            }

            if(PlayerPrefs.GetString("GameType")=="GroupVersus")
            {
                //Handles time calculation for Group Versus.
                CalculateTime_Group_Team();

            }
            if (PlayerPrefs.GetString("GameType")=="SingleQuickPlay")
            {
                //Handles time calculation for Group Versus.
                CalculateTime_Single_QuickPlay();
            }
        }
        #endregion

        #region Charade Detail Time

        if(PlayerPrefs.GetString("GameType")=="GroupVersus")
        {
            //Handles time calculation for Charade Details Panel.
            CalculateTime_Group_Team();
        }
        if(PlayerPrefs.GetString("GameType")=="SingleQuickPlay")
        {
            //Handles time calculation for Charade Details Panel.
            CalculateTime_Single_QuickPlay();
        }
        #endregion
    }


    #region Group Team Game Design.
    public void CalculateTime_Group_Team()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            string timeString;
            if (timeRemaining < 60)
            {
                timeString = string.Format("{0:00}:{1:00}" + " Secs", minutes, seconds);
                low_timeText.text = timeString;
                low_Group_Team_Eng_GameTimeText.text = timeString;
            }
            else
            {
                timeString = string.Format("{0:00}:{1:00}" + " Mins", minutes, seconds);
                low_timeText.text = timeString;
                low_Group_Team_Eng_GameTimeText.text = timeString;
            }
        }
        else
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            string timeString;
            if (timeRemaining < 60)
            {
                timeString = string.Format("{0:00}:{1:00}" + " Secs", minutes, seconds);
                high_timeText.text = timeString;
                high_Group_Team_Eng_GameTimeText.text = timeString;
            }
            else
            {
                timeString = string.Format("{0:00}:{1:00}" + " Mins", minutes, seconds);
                high_timeText.text = timeString;
                high_Group_Team_Eng_GameTimeText.text = timeString;
            }
        }

    }

    public void Group_TeamGameplayDesign()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Team Setting Data Text Config
            int selectedTeamValue = PlayerPrefs.GetInt("SelectedTeamsValue");
            int selectedRoundValue = PlayerPrefs.GetInt("SelectedRoundValue");
            if (selectedTeamValue != 0 && selectedRoundValue != 0)
            {
                low_Group_Team_Eng_SettingData.fontSize = 60;
                low_Group_Team_Eng_SettingData.text = "Team : " + selectedTeamValue.ToString() + " : " + " Round : " + selectedRoundValue.ToString();
            }

            StartCoroutine(Group_Team_startPlayingMatches());
            OpenRoundsInScoreDetails();
        }
        else
        {
            //Team Setting Data Text Config
            int selectedTeamValue = PlayerPrefs.GetInt("SelectedTeamsValue");
            int selectedRoundValue = PlayerPrefs.GetInt("SelectedRoundValue");
            if (selectedTeamValue != 0 && selectedRoundValue != 0)
            {
                high_Group_Team_Eng_SettingData.fontSize = 60;
                high_Group_Team_Eng_SettingData.text = "Team : " + selectedTeamValue.ToString() + " : " + " Round : " + selectedRoundValue.ToString();
            }

            StartCoroutine(Group_Team_startPlayingMatches());
            OpenRoundsInScoreDetails();
        }

    }

    public void Group_Team_MainGameProcess()
    {
        StartTimer();
        Group_Team_showNextWord();
    }

    IEnumerator Group_Team_startPlayingMatches()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Low Res UI.
            selectedTeamValue = PlayerPrefs.GetInt("SelectedTeamsValue");
            selectedRoundValue = PlayerPrefs.GetInt("SelectedRoundValue");
            //Create a Dictionary According to Teams Created.
            createDictionaryForTeamsCorrectAnswers();
            //Create public Lists According to Team Created for Showing Answers

            int totalMatches = selectedRoundValue * selectedTeamValue;

            Debug.Log("Total Match:" + totalMatches);
            Debug.Log("Current Match:" + currentMatch);

            while (currentMatch < totalMatches)
            {
                low_Group_Team_Eng_SettingData.text = "Team : " + (currentMatch % selectedTeamValue + 1).ToString() + " : " + " Round : " + (currentMatch / selectedTeamValue + 1).ToString();
                Debug.Log(low_Group_Team_Eng_SettingData.text);
                roundEnded = false;
                StartCoroutine(Group_Team_CountDown());
                yield return new WaitUntil(() => roundEnded);

                if (currentMatch != totalMatches)
                {
                    currentMatch += 1;
                    Debug.Log("Current Match:" + currentMatch);
                }
                low_Eng_CharadeDetails.SetActive(false);
                if (currentMatch == totalMatches)
                {

                    StopCoroutine(Group_Team_startPlayingMatches());
                    Group_Team_ResetRound();

                    low_GameOverPanel.SetActive(true);
                    low_GameOverPanel_animator.SetBool("IsOpen", true);
                    GameOverMenu.instance.low_groupVerusGameOverItems.SetActive(true);
                    CalculateWinningTeam();
                    //showCorrectWordsAtGamoverPanelForTeamsOnly();
                    low_Group_TeamsSection.SetActive(false);
                    soundManager.PlayFinalScoreSound();
                    low_groupSection.SetActive(false);
                    //gameSection.SetActive(false);
                    low_gameSection_animator.SetBool("IsOpen", false);
                    //StartCoroutine(CloseGameSectionAfterFewSec());
                }
            }
        }
        else
        {
            //High Res UI.
            selectedTeamValue = PlayerPrefs.GetInt("SelectedTeamsValue");
            selectedRoundValue = PlayerPrefs.GetInt("SelectedRoundValue");
            //Create a Dictionary According to Teams Created.
            createDictionaryForTeamsCorrectAnswers();
            //Create public Lists According to Team Created for Showing Answers

            int totalMatches = selectedRoundValue * selectedTeamValue;

            Debug.Log("Total Match:" + totalMatches);
            Debug.Log("Current Match:" + currentMatch);

            while (currentMatch < totalMatches)
            {
                high_Group_Team_Eng_SettingData.text = "Team : " + (currentMatch % selectedTeamValue + 1).ToString() + " : " + " Round : " + (currentMatch / selectedTeamValue + 1).ToString();
                Debug.Log(high_Group_Team_Eng_SettingData.text);
                roundEnded = false;
                StartCoroutine(Group_Team_CountDown());
                yield return new WaitUntil(() => roundEnded);

                if (currentMatch != totalMatches)
                {
                    currentMatch += 1;
                    Debug.Log("Current Match:" + currentMatch);
                }
                high_Eng_CharadeDetails.SetActive(false);
                if (currentMatch == totalMatches)
                {

                    StopCoroutine(Group_Team_startPlayingMatches());
                    Group_Team_ResetRound();

                    high_GameOverPanel.SetActive(true);
                    high_GameOverPanel_animator.SetBool("IsOpen", true);
                    GameOverMenu.instance.high_groupVerusGameOverItems.SetActive(true);
                    CalculateWinningTeam();
                    //showCorrectWordsAtGamoverPanelForTeamsOnly();
                    high_Group_TeamsSection.SetActive(false);
                    soundManager.PlayFinalScoreSound();
                    high_groupSection.SetActive(false);
                    //gameSection.SetActive(false);
                    high_gameSection_animator.SetBool("IsOpen", false);
                    //StartCoroutine(CloseGameSectionAfterFewSec());
                }
            }

        }
      

    }



    IEnumerator Group_Team_CountDown()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            low_countDownCreamPanel.SetActive(true);
            low_gameSection.SetActive(true);
            low_gameSection_animator.SetBool("IsOpen", true);
            getCategoryWords();
            soundManager.PlayBeforeCountDownSound();
            low_Group_Team_Eng_SettingData.gameObject.SetActive(true);
            low_Group_Team_Eng_GameTimeText.gameObject.SetActive(false);
            foreach (GameObject g in low_Group_Team_Eng_CountDownItems)
            {

                low_Group_Team_CloseButton.GetComponent<Button>().interactable = false;
                g.SetActive(true);
                yield return new WaitForSeconds(1f);
                g.SetActive(false);

                low_Group_Team_CloseButton.GetComponent<Button>().interactable = true;

            }
            low_countDownCreamPanel.SetActive(false);
            low_gameWhitePanel.SetActive(true);
            low_Group_Team_Eng_SettingData.gameObject.SetActive(false);
            low_Group_Team_Eng_GameTimeText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("GameStarted", 1);
            low_Group_Team_WordText.gameObject.SetActive(true);
            Group_Team_MainGameProcess();
        }
        else
        {
            high_countDownCreamPanel.SetActive(true);
            high_gameSection.SetActive(true);
            high_gameSection_animator.SetBool("IsOpen", true);
            getCategoryWords();
            soundManager.PlayBeforeCountDownSound();
            high_Group_Team_Eng_SettingData.gameObject.SetActive(true);
            high_Group_Team_Eng_GameTimeText.gameObject.SetActive(false);
            foreach (GameObject g in high_Group_Team_Eng_CountDownItems)
            {

                high_Group_Team_CloseButton.GetComponent<Button>().interactable = false;
                g.SetActive(true);
                yield return new WaitForSeconds(1f);
                g.SetActive(false);

                high_Group_Team_CloseButton.GetComponent<Button>().interactable = true;

            }
            high_countDownCreamPanel.SetActive(false);
            high_gameWhitePanel.SetActive(true);
            high_Group_Team_Eng_SettingData.gameObject.SetActive(false);
            high_Group_Team_Eng_GameTimeText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("GameStarted", 1);
            high_Group_Team_WordText.gameObject.SetActive(true);
            Group_Team_MainGameProcess();
        }
        
    }
    public void Group_Team_showNextWord()
    {
        if (!canShowNextWord)
        {
            canShowNextWord = true;
            if (currentWordIndex >= WordList.Count)
            {
                Debug.Log("No More words to show");
            }
            else
            {
                if (shownWords.Count == WordList.Count)
                {
                    Debug.Log("All words have been shown");
                    return;
                }
                do
                {
                    nextWord = WordList[Random.Range(0, WordList.Count)];

                }
                while (shownWords.Contains(nextWord));

                if (lastWordSaved)
                {
                    lastWordSaved = false;
                    previousWord = currentWord;
                    currentWord = nextWord;
                    if(PlayerPrefs.GetString("UIType")=="lowRes")
                    {
                        low_Group_Team_WordText.text = nextWord;
                    }
                   else
                    {
                        high_Group_Team_WordText.text = nextWord;
                    }
                    shownWords.Add(currentWord);
                }

            }
        }
        canShowNextWord = false;

    }


    public void Group_Team_showNextWord_WrongFn()
    {
        if (!canShowNextWord)
        {
            Debug.Log("Entering Next Word Region");
            if (currentWordIndex >= WordList.Count)
            {
                Debug.Log("No More words to show");
            }
            else
            {
                if (shownWords.Count == WordList.Count)
                {
                    Debug.Log("All words have been shown");
                    return;
                }
                do
                {
                    Debug.Log("Showing Next Word");
                    nextWord = WordList[Random.Range(0, WordList.Count)];
                }
                while (shownWords.Contains(nextWord));
                {
                    Debug.Log("Shown Next Word");
                    if (PlayerPrefs.GetString("UIType") == "lowRes")
                    {
                        low_Group_Team_WordText.text = nextWord;
                    }
                    else
                    {
                        high_Group_Team_WordText.text = nextWord;
                    }
                       
                    currentWord = nextWord;
                    shownWords.Add(nextWord);
                }
            }
            canShowNextWord = true;
            Debug.Log("canShowNextWord Value:True");
        }
    }

    IEnumerator Group_Team_ShowCorrectAnswerPanel()
    {
        if (PlayerPrefs.GetString("UIType") == "lowRes")
        {
            StopTimer();
            low_Group_Team_WordText.gameObject.SetActive(false);
            low_Group_Team_CorrectAnswerPanel.SetActive(true);

            yield return new WaitForSeconds(1.2f);
            low_Group_Team_CorrectAnswerPanel.SetActive(false);
            low_Group_Team_WordText.gameObject.SetActive(true);
            correctImageShown = true;
            StartTimer();
        }
        else
        {
            StopTimer();
            high_Group_Team_WordText.gameObject.SetActive(false);
            high_Group_Team_CorrectAnswerPanel.SetActive(true);

            yield return new WaitForSeconds(1.2f);
            high_Group_Team_CorrectAnswerPanel.SetActive(false);
            high_Group_Team_WordText.gameObject.SetActive(true);
            correctImageShown = true;
            StartTimer();
        }

    }
    IEnumerator Group_Team_ShowPassAnswerPanel()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            StopTimer();
            low_Group_Team_WordText.gameObject.SetActive(false);
            low_Group_Team_PassAnswerPanel.SetActive(true);

            yield return new WaitForSeconds(1.2f);
            low_Group_Team_PassAnswerPanel.SetActive(false);
            low_Group_Team_WordText.gameObject.SetActive(true);
            correctImageShown = true;
            StartTimer();
        }
        else
        {
            StopTimer();
            high_Group_Team_WordText.gameObject.SetActive(false);
            high_Group_Team_PassAnswerPanel.SetActive(true);

            yield return new WaitForSeconds(1.2f);
            high_Group_Team_PassAnswerPanel.SetActive(false);
            high_Group_Team_WordText.gameObject.SetActive(true);
            correctImageShown = true;
            StartTimer();
        }

    }

    public void Group_Team_ResetRound()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Low Res UI.
            PlayerPrefs.SetInt("GameStarted", 0);
            WordList.Clear();
            shownWords.Clear();
            nextWord = "";
            currentWord = "";
            low_Group_Team_WordText.gameObject.SetActive(false);
            low_groupSection.SetActive(false);
            low_ResetRoundPanel.SetActive(true);
            StopTimer();
            timeRemaining = totalTime;
            UnityAds.instance.showInterstitialAds();
            InstatiateRestRoundObjects();
        }
        else
        {
            //High Res UI.
            PlayerPrefs.SetInt("GameStarted", 0);
            WordList.Clear();
            shownWords.Clear();
            nextWord = "";
            currentWord = "";
            high_Group_Team_WordText.gameObject.SetActive(false);
            high_groupSection.SetActive(false);
            high_ResetRoundPanel.SetActive(true);

            StopTimer();
            timeRemaining = totalTime;
            UnityAds.instance.showInterstitialAds();
            InstatiateRestRoundObjects();
        }
       

    }

    public void Group_Team_FinishGame()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Low Res UI.
            teams.Clear();
            WordList.Clear();
            shownWords.Clear();
            Temp_TeamList1.Clear();
            Temp_TeamList2.Clear();
            Temp_TeamList3.Clear();
            Temp_TeamList4.Clear();
            Temp_TeamList1_Wrong.Clear();
            Temp_TeamList2_Wrong.Clear();
            Temp_TeamList3_Wrong.Clear();
            Temp_TeamList4_Wrong.Clear();
            nextWord = "";
            currentWord = "";
            low_GameOverPanel_animator.SetBool("IsOpen", false);
            StartCoroutine(CloseGameoverMenuAfterFewSec());
            //GameOverPanel.SetActive(false);
            low_ResetRoundPanel.SetActive(false);
            low_Group_TeamsSection.SetActive(true);
            low_groupSection.SetActive(true);
            low_gameSection.SetActive(true);
            low_gameSection_animator.SetBool("IsOpen", true);
            low_Group_Team_WordText.gameObject.SetActive(false);
            roundEnded = true;
            StopTimer();
            timeRemaining = totalTime;
            currentMatch = 0;
            //Clearing All CorrectAnswers
            correctAnswerGivenT1R1 = 0;
            correctAnswerGivenT1R2 = 0;
            correctAnswerGivenT1R3 = 0;
            correctAnswerGivenT1R4 = 0;
            correctAnswerGivenT1R5 = 0;
            correctAnswerGivenT1R6 = 0;
            correctAnswerGivenT1R7 = 0;

            correctAnswerGivenT2R1 = 0;
            correctAnswerGivenT2R2 = 0;
            correctAnswerGivenT2R3 = 0;
            correctAnswerGivenT2R4 = 0;
            correctAnswerGivenT2R5 = 0;
            correctAnswerGivenT2R6 = 0;
            correctAnswerGivenT2R7 = 0;

            correctAnswerGivenT3R1 = 0;
            correctAnswerGivenT3R2 = 0;
            correctAnswerGivenT3R3 = 0;
            correctAnswerGivenT3R4 = 0;
            correctAnswerGivenT3R5 = 0;
            correctAnswerGivenT3R6 = 0;
            correctAnswerGivenT3R7 = 0;

            correctAnswerGivenT4R1 = 0;
            correctAnswerGivenT4R2 = 0;
            correctAnswerGivenT4R3 = 0;
            correctAnswerGivenT4R4 = 0;
            correctAnswerGivenT4R5 = 0;
            correctAnswerGivenT4R6 = 0;
            correctAnswerGivenT4R7 = 0;

            for (int i = 0; i < low_roundsObjs.Length; i++)
            {
                low_roundsObjs[i].transform.GetChild(1).transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().text = "0";
                low_roundsObjs[i].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                low_roundsObjs[i].transform.GetChild(1).transform.GetChild(1).transform.GetChild(3).GetComponent<Text>().text = "0";
                low_roundsObjs[i].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                low_roundsObjs[i].transform.GetChild(1).transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text = "0";
                low_roundsObjs[i].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
                low_roundsObjs[i].transform.GetChild(1).transform.GetChild(3).transform.GetChild(3).GetComponent<Text>().text = "0";
                low_roundsObjs[i].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
            }


            foreach (GameObject g in goWords)
            {
                Destroy(g);
            }

            Group_TeamGameplayDesign();
        }
        else
        {
            //High Res UI.
            teams.Clear();
            WordList.Clear();
            shownWords.Clear();
            Temp_TeamList1.Clear();
            Temp_TeamList2.Clear();
            Temp_TeamList3.Clear();
            Temp_TeamList4.Clear();
            Temp_TeamList1_Wrong.Clear();
            Temp_TeamList2_Wrong.Clear();
            Temp_TeamList3_Wrong.Clear();
            Temp_TeamList4_Wrong.Clear();
            nextWord = "";
            currentWord = "";
            high_GameOverPanel_animator.SetBool("IsOpen", false);
            StartCoroutine(CloseGameoverMenuAfterFewSec());
            //GameOverPanel.SetActive(false);
            high_ResetRoundPanel.SetActive(false);
            high_Group_TeamsSection.SetActive(true);
            high_groupSection.SetActive(true);
            high_gameSection.SetActive(true);
            high_gameSection_animator.SetBool("IsOpen", true);
            high_Group_Team_WordText.gameObject.SetActive(false);
            roundEnded = true;
            StopTimer();
            timeRemaining = totalTime;
            currentMatch = 0;
            //Clearing All CorrectAnswers
            correctAnswerGivenT1R1 = 0;
            correctAnswerGivenT1R2 = 0;
            correctAnswerGivenT1R3 = 0;
            correctAnswerGivenT1R4 = 0;
            correctAnswerGivenT1R5 = 0;
            correctAnswerGivenT1R6 = 0;
            correctAnswerGivenT1R7 = 0;

            correctAnswerGivenT2R1 = 0;
            correctAnswerGivenT2R2 = 0;
            correctAnswerGivenT2R3 = 0;
            correctAnswerGivenT2R4 = 0;
            correctAnswerGivenT2R5 = 0;
            correctAnswerGivenT2R6 = 0;
            correctAnswerGivenT2R7 = 0;

            correctAnswerGivenT3R1 = 0;
            correctAnswerGivenT3R2 = 0;
            correctAnswerGivenT3R3 = 0;
            correctAnswerGivenT3R4 = 0;
            correctAnswerGivenT3R5 = 0;
            correctAnswerGivenT3R6 = 0;
            correctAnswerGivenT3R7 = 0;

            correctAnswerGivenT4R1 = 0;
            correctAnswerGivenT4R2 = 0;
            correctAnswerGivenT4R3 = 0;
            correctAnswerGivenT4R4 = 0;
            correctAnswerGivenT4R5 = 0;
            correctAnswerGivenT4R6 = 0;
            correctAnswerGivenT4R7 = 0;

            for (int i = 0; i < high_roundsObjs.Length; i++)
            {
                high_roundsObjs[i].transform.GetChild(1).transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().text = "0";
                high_roundsObjs[i].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                high_roundsObjs[i].transform.GetChild(1).transform.GetChild(1).transform.GetChild(3).GetComponent<Text>().text = "0";
                high_roundsObjs[i].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                high_roundsObjs[i].transform.GetChild(1).transform.GetChild(2).transform.GetChild(3).GetComponent<Text>().text = "0";
                high_roundsObjs[i].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
                high_roundsObjs[i].transform.GetChild(1).transform.GetChild(3).transform.GetChild(3).GetComponent<Text>().text = "0";
                high_roundsObjs[i].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
            }


            foreach (GameObject g in goWords)
            {
                Destroy(g);
            }

            Group_TeamGameplayDesign();
        }
       

    }

    #endregion


    #region Single QuickPlay Game Design

    public void CalculateTime_Single_QuickPlay()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            string timeString;

            if (timeRemaining < 60)
            {

                timeString = string.Format("{0:00}:{1:00}" + " Secs", minutes, seconds);
            }
            else
            {
                timeString = string.Format("{0:00}:{1:00}" + " Mins", minutes, seconds);
            }

            low_timeText.text = timeString;
            low_Single_QuickPlay_Eng_GameTimeText.text = timeString;
        }
        else
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            string timeString;

            if (timeRemaining < 60)
            {

                timeString = string.Format("{0:00}:{1:00}" + " Secs", minutes, seconds);
            }
            else
            {
                timeString = string.Format("{0:00}:{1:00}" + " Mins", minutes, seconds);
            }

            high_timeText.text = timeString;
            high_Single_QuickPlay_Eng_GameTimeText.text = timeString;
        }

    }
    public void Single_QuickPlayDesign()
    {
        StartCoroutine(Single_QuickPlay_CountDown());
    }
    
    IEnumerator Single_QuickPlay_CountDown()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Low Res UI.
            low_countDownCreamPanel.SetActive(true);
            getCategoryWords();
            soundManager.PlayBeforeCountDownSound();
            if (!low_Single_QuickPlay_Eng_GameTimeText.gameObject.activeSelf)
            {
                low_Single_QuickPlay_Eng_GameTimeText.gameObject.SetActive(true);
            }
            foreach (GameObject g in low_Single_QuickPlay_Eng_CountDownItems)
            {
                low_Single_QuickPlay_CloseButton.GetComponent<Button>().interactable = false;
                low_Single_QuickPlay_CorrectAnswerButton.SetActive(false);
                low_Single_QuickPlay_WrongAnswerButton.SetActive(false);
                g.SetActive(true);
                yield return new WaitForSeconds(1f);
                g.SetActive(false);
                low_Single_QuickPlay_CorrectAnswerButton.SetActive(true);
                low_Single_QuickPlay_WrongAnswerButton.SetActive(true);
                low_Single_QuickPlay_CloseButton.GetComponent<Button>().interactable = true;

            }
            low_countDownCreamPanel.SetActive(false);
            low_gameWhitePanel.SetActive(true); //TODO: Close at GameOver
            low_Single_QuickPlay_WordText.gameObject.SetActive(true);
            low_Eng_CharadeDetails.SetActive(false);
            Single_QuickPlay_MainGameProcess();
        }
        else
        {
            //High Res UI.
            high_countDownCreamPanel.SetActive(true);
            getCategoryWords();
            soundManager.PlayBeforeCountDownSound();
            if (!high_Single_QuickPlay_Eng_GameTimeText.gameObject.activeSelf)
            {
                high_Single_QuickPlay_Eng_GameTimeText.gameObject.SetActive(true);
                
            }
            foreach (GameObject g in high_Single_QuickPlay_Eng_CountDownItems)
            {
                high_Single_QuickPlay_CloseButton.GetComponent<Button>().interactable = false;
                high_Single_QuickPlay_CorrectAnswerButton.SetActive(false);
                high_Single_QuickPlay_WrongAnswerButton.SetActive(false);
                g.SetActive(true);
                yield return new WaitForSeconds(1f);
                g.SetActive(false);
                high_Single_QuickPlay_CorrectAnswerButton.SetActive(true);
                high_Single_QuickPlay_WrongAnswerButton.SetActive(true);
                high_Single_QuickPlay_CloseButton.GetComponent<Button>().interactable = true;

            }
            high_countDownCreamPanel.SetActive(false);
            high_gameWhitePanel.SetActive(true); //TODO: Close at GameOver
            high_Single_QuickPlay_WordText.gameObject.SetActive(true);
            high_Eng_CharadeDetails.SetActive(false);
            Single_QuickPlay_MainGameProcess();
        }
        
    }

    public void Single_QuickPlay_MainGameProcess()
    {
        StartTimer();
        Single_QuickPlay_ShowNextWord();
    }
    public void Single_QuickPlay_ShowNextWord()
    {
        if (currentWordIndex >= WordList.Count)
        {
            Debug.Log("No More words to show");
        }
        else
        {
            if (shownWords.Count == WordList.Count)
            {
                Debug.Log("All words have been shown");
                //shownWords.Clear();
                return;
            }
            do
            {
                nextWord = WordList[Random.Range(0, WordList.Count)];
            }
            while (shownWords.Contains(nextWord));
            {
                if(PlayerPrefs.GetString("UIType")=="lowRes")
                {
                   low_Single_QuickPlay_WordText.text = nextWord;
                }
                else
                {
                    high_Single_QuickPlay_WordText.text = nextWord;
                }

                currentWord = nextWord;
                shownWords.Add(nextWord);
            }
        }
    }

    IEnumerator Single_QuickPlay_ShowCorrectAnswerPanel()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            yield return new WaitForSeconds(0.1f);
            StopTimer();
            low_Single_QuickPlay_WordText.gameObject.SetActive(false);
            low_Single_QuickPlay_CorrectAnswerPanel.SetActive(true);
            low_Single_QuickPlay_CorrectAnswerButton.SetActive(false);
            low_Single_QuickPlay_WrongAnswerButton.SetActive(false);

            yield return new WaitForSeconds(1.2f);
            low_Single_QuickPlay_CorrectAnswerPanel.SetActive(false);
            low_Single_QuickPlay_WordText.gameObject.SetActive(true);
            low_Single_QuickPlay_CorrectAnswerButton.SetActive(true);
            low_Single_QuickPlay_WrongAnswerButton.SetActive(true);
            Single_QuickPlay_ShowNextWord();
            StartTimer();
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            StopTimer();
            high_Single_QuickPlay_WordText.gameObject.SetActive(false);
            high_Single_QuickPlay_CorrectAnswerPanel.SetActive(true);
            high_Single_QuickPlay_CorrectAnswerButton.SetActive(false);
            high_Single_QuickPlay_WrongAnswerButton.SetActive(false);

            yield return new WaitForSeconds(1.2f);
            high_Single_QuickPlay_CorrectAnswerPanel.SetActive(false);
            high_Single_QuickPlay_WordText.gameObject.SetActive(true);
            high_Single_QuickPlay_CorrectAnswerButton.SetActive(true);
            high_Single_QuickPlay_WrongAnswerButton.SetActive(true);
            Single_QuickPlay_ShowNextWord();
            StartTimer();
        }
           
    }

    IEnumerator Single_QuickPlay_ShowPassAnswerPanel()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            yield return new WaitForSeconds(0.1f);
            StopTimer();
            low_Single_QuickPlay_WordText.gameObject.SetActive(false);
            low_Single_QuickPlay_PassAnswerPanel.SetActive(true);
            low_Single_QuickPlay_CorrectAnswerButton.SetActive(false);
            low_Single_QuickPlay_WrongAnswerButton.SetActive(false);

            yield return new WaitForSeconds(1.2f);
            low_Single_QuickPlay_PassAnswerPanel.SetActive(false);
            low_Single_QuickPlay_WordText.gameObject.SetActive(true);
            low_Single_QuickPlay_CorrectAnswerButton.SetActive(true);
            low_Single_QuickPlay_WrongAnswerButton.SetActive(true);
            Single_QuickPlay_ShowNextWord();
            StartTimer();


        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            StopTimer();
            high_Single_QuickPlay_WordText.gameObject.SetActive(false);
            high_Single_QuickPlay_PassAnswerPanel.SetActive(true);
            high_Single_QuickPlay_CorrectAnswerButton.SetActive(false);
            high_Single_QuickPlay_WrongAnswerButton.SetActive(false);

            yield return new WaitForSeconds(1.2f);
            high_Single_QuickPlay_PassAnswerPanel.SetActive(false);
            high_Single_QuickPlay_WordText.gameObject.SetActive(true);
            high_Single_QuickPlay_CorrectAnswerButton.SetActive(true);
            high_Single_QuickPlay_WrongAnswerButton.SetActive(true);
            Single_QuickPlay_ShowNextWord();
            StartTimer();


        }

    }

    public void Single_QuickPlay_ResetRound()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            WordList.Clear();
            shownWords.Clear();
            nextWord = "";
            currentWord = "";
            low_Single_QuickPlay_WordText.gameObject.SetActive(false);
            StopTimer();
            timeRemaining = totalTime;
            roundEnded = true;
            soundManager.PlayFinalScoreSound();
            UnityAds.instance.showInterstitialAds();
            low_GameOverPanel.SetActive(true);
            low_GameOverPanel_animator.SetBool("IsOpen", true);
            GameOverMenu.instance.low_singleQuickPlayGameOverItems.SetActive(true);
            showCorrectAnswerAtGameOverPanelForQuickPlayOnly();
        }
        else
        {
            WordList.Clear();
            shownWords.Clear();
            nextWord = "";
            currentWord = "";
            high_Single_QuickPlay_WordText.gameObject.SetActive(false);
            StopTimer();
            timeRemaining = totalTime;
            roundEnded = true;
            soundManager.PlayFinalScoreSound();
            UnityAds.instance.showInterstitialAds();
            high_GameOverPanel.SetActive(true);
            high_GameOverPanel_animator.SetBool("IsOpen", true);
            GameOverMenu.instance.high_singleQuickPlayGameOverItems.SetActive(true);
            showCorrectAnswerAtGameOverPanelForQuickPlayOnly();
        }
        

    }

    public void Single_QuickPlay_FinishGame()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            low_GameOverPanel_animator.SetBool("IsOpen", false);
            StartCoroutine(CloseGameoverMenuAfterFewSec());
            low_Single_QuickPlaySection.SetActive(false);
            low_singleSection.SetActive(false);
            Single_QuickPlay_CorrectAnswerGiven.Clear();
            Single_QuickPlay_WrongAnswerGiven.Clear();
            StartNewGame();
        }
        else
        {
            high_GameOverPanel_animator.SetBool("IsOpen", false);
            StartCoroutine(CloseGameoverMenuAfterFewSec());
            low_Single_QuickPlaySection.SetActive(false);
            low_singleSection.SetActive(false);
            Single_QuickPlay_CorrectAnswerGiven.Clear();
            Single_QuickPlay_WrongAnswerGiven.Clear();
            StartNewGame();
        }
        
    }


    #endregion


    #region Showing CorrectWords at GameOver Panel.
    public void showCorrectAnswerAtGameOverPanelForQuickPlayOnly()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            if (PlayerPrefs.GetString("GameType") == "SingleQuickPlay")
            {
                GameOverMenu.instance.low_single_correctAnswersGiven.text = Single_QuickPlay_CorrectAnswerGiven.Count.ToString();
                GameOverMenu.instance.low_single_wrongAnswersGiven.text = Single_QuickPlay_WrongAnswerGiven.Count.ToString();
                if(Single_QuickPlay_CorrectAnswerGiven.Count==0 && Single_QuickPlay_WrongAnswerGiven.Count==0)
                {
                    low_Single_QuickPlay_NoWordsFound.SetActive(true);
                }
                else
                {
                    low_Single_QuickPlay_NoWordsFound.SetActive(false);
                }
            }
        }
        else
        {
            if (PlayerPrefs.GetString("GameType") == "SingleQuickPlay")
            {
                GameOverMenu.instance.high_single_correctAnswersGiven.text = Single_QuickPlay_CorrectAnswerGiven.Count.ToString();
                GameOverMenu.instance.high_single_wrongAnswersGiven.text = Single_QuickPlay_WrongAnswerGiven.Count.ToString();
                if (Single_QuickPlay_CorrectAnswerGiven.Count == 0 && Single_QuickPlay_WrongAnswerGiven.Count == 0)
                {
                    high_Single_QuickPlay_NoWordsFound.SetActive(true);
                }
                else
                {
                    high_Single_QuickPlay_NoWordsFound.SetActive(false);
                }
            }
        }

    }

    #endregion

    #region Score Functionality.
    public void OpenRoundsInScoreDetails()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Low Res.
            int RoundstoOpen = selectedRoundValue;
            int TeamsToOpen = selectedTeamValue;
            for (int i = 0; i < low_roundsObjs.Length; i++)
            {
                if (i < RoundstoOpen)
                {
                    low_roundsObjs[i].gameObject.SetActive(true);
                    for (int j = 0; j < low_roundsObjs[i].gameObject.transform.GetChild(1).gameObject.transform.childCount; j++)
                    {
                        if (j < TeamsToOpen)
                        {
                            low_roundsObjs[i].gameObject.transform.GetChild(1).gameObject.transform.GetChild(j).gameObject.SetActive(true);

                        }
                        else
                        {
                            low_roundsObjs[i].gameObject.transform.GetChild(1).gameObject.transform.GetChild(j).gameObject.SetActive(false);
                        }
                    }

                }
                else
                {
                    low_roundsObjs[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            //High Res.
            int RoundstoOpen = selectedRoundValue;
            int TeamsToOpen = selectedTeamValue;
            for (int i = 0; i < high_roundsObjs.Length; i++)
            {
                if (i < RoundstoOpen)
                {
                    high_roundsObjs[i].gameObject.SetActive(true);
                    for (int j = 0; j < high_roundsObjs[i].gameObject.transform.GetChild(1).gameObject.transform.childCount; j++)
                    {
                        if (j < TeamsToOpen)
                        {
                            high_roundsObjs[i].gameObject.transform.GetChild(1).gameObject.transform.GetChild(j).gameObject.SetActive(true);

                        }
                        else
                        {
                            high_roundsObjs[i].gameObject.transform.GetChild(1).gameObject.transform.GetChild(j).gameObject.SetActive(false);
                        }
                    }

                }
                else
                {
                    high_roundsObjs[i].gameObject.SetActive(false);
                }
            }
        }
        
    }

    public void Open_Group_Team_ScoreCardDetails()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
           low_Group_Team_ScoreCardPanel.SetActive(true);
        }
        else
        {
            high_Group_Team_ScoreCardPanel.SetActive(true);
        }
    }

    public void getRoundWiseLenghtOfTeamsAnswers()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Low Res.
            int currentScore = 0;
            int totalScore = 0;

            switch (currentTeam)
            {
                case 1:
                    switch (currentRound)
                    {

                        case 1:

                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[0].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R1.ToString();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {
                                low_roundsObjs[1].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R2.ToString();
                            }
                            break;
                        case 3:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {
                                low_roundsObjs[2].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R3.ToString();
                            }
                            break;
                        case 4:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {
                                low_roundsObjs[3].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R4.ToString();
                            }
                            break;
                        case 5:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {
                                low_roundsObjs[4].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R5.ToString();
                            }
                            break;
                        case 6:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {
                                low_roundsObjs[5].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R6.ToString();
                            }
                            break;
                        case 7:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {
                                low_roundsObjs[6].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R7.ToString();
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (currentRound)
                    {

                        case 1:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[0].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R1.ToString();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[1].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R2.ToString();
                            }
                            break;
                        case 3:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[2].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R3.ToString();
                            }
                            break;
                        case 4:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[3].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R4.ToString();
                            }
                            break;
                        case 5:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[4].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R5.ToString();
                            }
                            break;
                        case 6:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[5].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R6.ToString();
                            }
                            break;
                        case 7:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[6].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R7.ToString();
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (currentRound)
                    {
                        case 1:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[0].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R1.ToString();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[1].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R2.ToString();
                            }
                            break;
                        case 3:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[2].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R3.ToString();
                            }
                            break;
                        case 4:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[3].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R4.ToString();
                            }
                            break;
                        case 5:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[4].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R5.ToString();
                            }
                            break;
                        case 6:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[5].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R6.ToString();
                            }
                            break;
                        case 7:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[6].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R7.ToString();
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (currentRound)
                    {
                        case 1:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[0].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R1.ToString();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[1].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R2.ToString();
                            }
                            break;
                        case 3:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[2].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R3.ToString();
                            }
                            break;
                        case 4:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[3].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R4.ToString();
                            }
                            break;
                        case 5:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[4].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R5.ToString();
                            }
                            break;
                        case 6:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[5].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R6.ToString();
                            }
                            break;
                        case 7:
                            for (int i = 0; i < low_roundsObjs.Length; i++)
                            {

                                low_roundsObjs[6].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R7.ToString();
                            }
                            break;
                    }
                    break;
            }
        }
        else
        {
            //High Res.
            int currentScore = 0;
            int totalScore = 0;

            switch (currentTeam)
            {
                case 1:
                    switch (currentRound)
                    {

                        case 1:

                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[0].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R1.ToString();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {
                                high_roundsObjs[1].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R2.ToString();
                            }
                            break;
                        case 3:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {
                                high_roundsObjs[2].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R3.ToString();
                            }
                            break;
                        case 4:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {
                                high_roundsObjs[3].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R4.ToString();
                            }
                            break;
                        case 5:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {
                                high_roundsObjs[4].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R5.ToString();
                            }
                            break;
                        case 6:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {
                                high_roundsObjs[5].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R6.ToString();
                            }
                            break;
                        case 7:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {
                                high_roundsObjs[6].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT1R7.ToString();
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (currentRound)
                    {

                        case 1:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[0].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R1.ToString();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[1].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R2.ToString();
                            }
                            break;
                        case 3:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[2].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R3.ToString();
                            }
                            break;
                        case 4:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[3].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R4.ToString();
                            }
                            break;
                        case 5:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[4].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R5.ToString();
                            }
                            break;
                        case 6:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[5].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R6.ToString();
                            }
                            break;
                        case 7:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[6].transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT2R7.ToString();
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (currentRound)
                    {
                        case 1:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[0].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R1.ToString();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[1].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R2.ToString();
                            }
                            break;
                        case 3:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[2].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R3.ToString();
                            }
                            break;
                        case 4:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[3].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R4.ToString();
                            }
                            break;
                        case 5:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[4].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R5.ToString();
                            }
                            break;
                        case 6:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[5].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R6.ToString();
                            }
                            break;
                        case 7:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[6].transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT3R7.ToString();
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (currentRound)
                    {
                        case 1:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[0].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R1.ToString();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[1].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R2.ToString();
                            }
                            break;
                        case 3:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[2].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R3.ToString();
                            }
                            break;
                        case 4:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[3].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R4.ToString();
                            }
                            break;
                        case 5:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[4].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R5.ToString();
                            }
                            break;
                        case 6:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[5].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R6.ToString();
                            }
                            break;
                        case 7:
                            for (int i = 0; i < high_roundsObjs.Length; i++)
                            {

                                high_roundsObjs[6].transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = correctAnswerGivenT4R7.ToString();
                            }
                            break;
                    }
                    break;
            }
        }

        

    }

    public void Open_Winner_TieTagRoundSection()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            string Round1WinningTeam = PlayerPrefs.GetString("OpenTagR1");
            switch (Round1WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[0].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[0].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[0].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[0].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round2WinningTeam = PlayerPrefs.GetString("OpenTagR2");
            switch (Round2WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[1].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[1].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[1].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[1].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round3WinningTeam = PlayerPrefs.GetString("OpenTagR3");
            switch (Round3WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[2].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[2].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[2].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[2].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round4WinningTeam = PlayerPrefs.GetString("OpenTagR4");
            switch (Round4WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[3].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[3].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[3].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[3].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round5WinningTeam = PlayerPrefs.GetString("OpenTagR5");
            switch (Round5WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[4].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[4].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[4].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[4].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round6WinningTeam = PlayerPrefs.GetString("OpenTagR6");
            switch (Round6WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[5].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[5].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[5].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[5].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round7WinningTeam = PlayerPrefs.GetString("OpenTagR7");
            switch (Round7WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[6].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[6].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[6].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < low_roundsObjs.Length; i++)
                    {
                        low_roundsObjs[6].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

        }
        else
        {
            string Round1WinningTeam = PlayerPrefs.GetString("OpenTagR1");
            switch (Round1WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[0].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[0].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[0].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[0].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round2WinningTeam = PlayerPrefs.GetString("OpenTagR2");
            switch (Round2WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[1].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[1].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[1].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[1].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round3WinningTeam = PlayerPrefs.GetString("OpenTagR3");
            switch (Round3WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[2].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[2].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[2].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[2].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round4WinningTeam = PlayerPrefs.GetString("OpenTagR4");
            switch (Round4WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[3].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[3].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[3].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[3].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round5WinningTeam = PlayerPrefs.GetString("OpenTagR5");
            switch (Round5WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[4].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[4].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[4].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[4].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round6WinningTeam = PlayerPrefs.GetString("OpenTagR6");
            switch (Round6WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[5].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[5].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[5].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[5].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

            string Round7WinningTeam = PlayerPrefs.GetString("OpenTagR7");
            switch (Round7WinningTeam)
            {
                case "Team 1":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[6].transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 2":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[6].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 3":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[6].transform.GetChild(1).transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
                case "Team 4":
                    for (int i = 0; i < high_roundsObjs.Length; i++)
                    {
                        high_roundsObjs[6].transform.GetChild(1).transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);

                    }
                    break;
            }

        }
    }
    public void SetWinner_TieTagInRoundSection()
    {
        //Round 1
        int round1Tag = Mathf.Max(correctAnswerGivenT1R1, correctAnswerGivenT2R1, correctAnswerGivenT3R1, correctAnswerGivenT4R1);
        if (round1Tag == correctAnswerGivenT1R1)
        {
            PlayerPrefs.SetString("OpenTagR1", "Team 1");
        }
        else if (round1Tag == correctAnswerGivenT2R1)
        {
            PlayerPrefs.SetString("OpenTagR1", "Team 2");
        }
        else if (round1Tag == correctAnswerGivenT3R1)
        {
            PlayerPrefs.SetString("OpenTagR1", "Team 3");
        }
        else if (round1Tag == correctAnswerGivenT4R1)
        {
            PlayerPrefs.SetString("OpenTagR1", "Team 4");
        }

        //Round 2
        int round2Tag = Mathf.Max(correctAnswerGivenT1R2, correctAnswerGivenT2R2, correctAnswerGivenT3R2, correctAnswerGivenT4R2);
        if (round2Tag == correctAnswerGivenT1R2)
        {
            PlayerPrefs.SetString("OpenTagR2", "Team 1");
        }
        else if (round2Tag == correctAnswerGivenT2R2)
        {
            PlayerPrefs.SetString("OpenTagR2", "Team 2");
        }
        else if (round2Tag == correctAnswerGivenT3R2)
        {
            PlayerPrefs.SetString("OpenTagR2", "Team 3");
        }
        else if (round2Tag == correctAnswerGivenT4R2)
        {
            PlayerPrefs.SetString("OpenTagR2", "Team 4");
        }

        //Round 3
        int round3Tag = Mathf.Max(correctAnswerGivenT1R3, correctAnswerGivenT2R3, correctAnswerGivenT3R3, correctAnswerGivenT4R3);
        if (round3Tag == correctAnswerGivenT1R3)
        {
            PlayerPrefs.SetString("OpenTagR3", "Team 1");
        }
        else if (round3Tag == correctAnswerGivenT2R3)
        {
            PlayerPrefs.SetString("OpenTagR3", "Team 2");
        }
        else if (round3Tag == correctAnswerGivenT3R3)
        {
            PlayerPrefs.SetString("OpenTagR3", "Team 3");
        }
        else if (round3Tag == correctAnswerGivenT4R3)
        {
            PlayerPrefs.SetString("OpenTagR3", "Team 4");
        }
        //Round 4
        int round4Tag = Mathf.Max(correctAnswerGivenT1R4, correctAnswerGivenT2R4, correctAnswerGivenT3R4, correctAnswerGivenT4R4);
        if (round4Tag == correctAnswerGivenT1R4)
        {
            PlayerPrefs.SetString("OpenTagR4", "Team 1");
        }
        else if (round4Tag == correctAnswerGivenT2R4)
        {
            PlayerPrefs.SetString("OpenTagR4", "Team 2");
        }
        else if (round4Tag == correctAnswerGivenT3R4)
        {
            PlayerPrefs.SetString("OpenTagR4", "Team 3");
        }
        else if (round4Tag == correctAnswerGivenT4R4)
        {
            PlayerPrefs.SetString("OpenTagR4", "Team 4");
        }

        //Round5
        int round5Tag = Mathf.Max(correctAnswerGivenT1R5, correctAnswerGivenT2R5, correctAnswerGivenT3R5, correctAnswerGivenT4R5);
        if (round5Tag == correctAnswerGivenT1R5)
        {
            PlayerPrefs.SetString("OpenTagR5", "Team 1");
        }
        else if (round5Tag == correctAnswerGivenT2R5)
        {
            PlayerPrefs.SetString("OpenTagR5", "Team 2");
        }
        else if (round5Tag == correctAnswerGivenT3R5)
        {
            PlayerPrefs.SetString("OpenTagR5", "Team 3");
        }
        else if (round5Tag == correctAnswerGivenT4R5)
        {
            PlayerPrefs.SetString("OpenTagR5", "Team 4");
        }

        //Round 6
        int round6Tag = Mathf.Max(correctAnswerGivenT1R6, correctAnswerGivenT2R6, correctAnswerGivenT3R6, correctAnswerGivenT4R6);
        if (round6Tag == correctAnswerGivenT1R6)
        {
            PlayerPrefs.SetString("OpenTagR6", "Team 1");
        }
        else if (round6Tag == correctAnswerGivenT2R6)
        {
            PlayerPrefs.SetString("OpenTagR6", "Team 2");
        }
        else if (round6Tag == correctAnswerGivenT3R6)
        {
            PlayerPrefs.SetString("OpenTagR6", "Team 3");
        }
        else if (round6Tag == correctAnswerGivenT4R6)
        {
            PlayerPrefs.SetString("OpenTagR6", "Team 4");
        }

        //Round 7

        int round7Tag = Mathf.Max(correctAnswerGivenT1R7, correctAnswerGivenT2R7, correctAnswerGivenT3R7, correctAnswerGivenT4R7);
        if (round7Tag == correctAnswerGivenT1R7)
        {
            PlayerPrefs.SetString("OpenTagR7", "Team 1");
        }
        else if (round7Tag == correctAnswerGivenT2R7)
        {
            PlayerPrefs.SetString("OpenTagR7", "Team 2");
        }
        else if (round7Tag == correctAnswerGivenT3R7)
        {
            PlayerPrefs.SetString("OpenTagR7", "Team 3");
        }
        else if (round7Tag == correctAnswerGivenT4R7)
        {
            PlayerPrefs.SetString("OpenTagR7", "Team 4");
        }
    }

    public void CalculateWinningTeam()
    {
        TotalScoreByTeam1 = correctAnswerGivenT1R1 + correctAnswerGivenT1R2 + correctAnswerGivenT1R3 + correctAnswerGivenT1R4 + correctAnswerGivenT1R5 + correctAnswerGivenT1R6 + correctAnswerGivenT1R7;
        Debug.Log("Scores By Team 1:" + TotalScoreByTeam1);
        int wrongAnswerByTeam1 = wrongAnswerGivenT1R1 + wrongAnswerGivenT1R2 + wrongAnswerGivenT1R3 + wrongAnswerGivenT1R4 + wrongAnswerGivenT1R5 + wrongAnswerGivenT1R6 + wrongAnswerGivenT1R7;
        Debug.Log("Wrong Answer by Team 1:" + wrongAnswerByTeam1);
        TotalScoreByTeam2 = correctAnswerGivenT2R1 + correctAnswerGivenT2R2 + correctAnswerGivenT2R3 + correctAnswerGivenT2R4 + correctAnswerGivenT2R5 + correctAnswerGivenT2R6 + correctAnswerGivenT2R7;
        Debug.Log("Scores By Team 2:" + TotalScoreByTeam2);
        int wrongAnswerByTeam2 = wrongAnswerGivenT2R1 + wrongAnswerGivenT2R2 + wrongAnswerGivenT2R3 + wrongAnswerGivenT2R4 + wrongAnswerGivenT2R5 + wrongAnswerGivenT2R6 + wrongAnswerGivenT2R7;
        Debug.Log("Wrong Answer by Team 2:" + wrongAnswerByTeam2);
        TotalScoreByTeam3 = correctAnswerGivenT3R1 + correctAnswerGivenT3R2 + correctAnswerGivenT3R3 + correctAnswerGivenT3R4 + correctAnswerGivenT3R5 + correctAnswerGivenT3R6 + correctAnswerGivenT3R7;
        Debug.Log("Scores By Team 3:" + TotalScoreByTeam3);
        int wrongAnswerByTeam3 = wrongAnswerGivenT3R1 + wrongAnswerGivenT3R2 + wrongAnswerGivenT3R3 + wrongAnswerGivenT3R4 + wrongAnswerGivenT3R5 + wrongAnswerGivenT3R6 + wrongAnswerGivenT3R7;
        Debug.Log("Wrong Answer by Team 3:"+ wrongAnswerByTeam3);
        TotalScoreByTeam4 = correctAnswerGivenT4R1 + correctAnswerGivenT4R2 + correctAnswerGivenT4R3 + correctAnswerGivenT4R4 + correctAnswerGivenT4R5 + correctAnswerGivenT4R6 + correctAnswerGivenT4R7;
        Debug.Log("Scores By Team 4:" + TotalScoreByTeam4);
        int wrongAnswerByTeam4 = wrongAnswerGivenT4R1 + wrongAnswerGivenT4R2 + wrongAnswerGivenT4R3 + wrongAnswerGivenT4R4 + wrongAnswerGivenT4R5 + wrongAnswerGivenT4R6 + wrongAnswerGivenT4R7;
        Debug.Log("Scores By Team 5:" + wrongAnswerByTeam4);

        int WinningTeamScores = Mathf.Max(TotalScoreByTeam1, TotalScoreByTeam2, TotalScoreByTeam3, TotalScoreByTeam4);

        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            low_FinalScoreText.text = WinningTeamScores.ToString();
        }
        else
        {
            high_FinalScoreText.text = WinningTeamScores.ToString();
        }
        

        if (WinningTeamScores == TotalScoreByTeam1)
        {
            PlayerPrefs.SetString("WinningTeam", "Team 1");
            PlayerPrefs.SetInt("CorrectAnswerByTeam1", TotalScoreByTeam1);
            PlayerPrefs.SetInt("WrongAnswerByTeam1", wrongAnswerByTeam1);
        }
        else if (WinningTeamScores == TotalScoreByTeam2)
        {
            PlayerPrefs.SetString("WinningTeam", "Team 2");
            PlayerPrefs.SetInt("CorrectAnswerByTeam2", TotalScoreByTeam2);
            PlayerPrefs.SetInt("WrongAnswerByTeam2", wrongAnswerByTeam2);
        }
        else if (WinningTeamScores == TotalScoreByTeam3)
        {
            PlayerPrefs.SetString("WinningTeam", "Team 3");
            PlayerPrefs.SetInt("CorrectAnswerByTeam3", TotalScoreByTeam3);
            PlayerPrefs.SetInt("WrongAnswerByTeam3", wrongAnswerByTeam3);
        }
        else if (WinningTeamScores == TotalScoreByTeam4)
        {
            PlayerPrefs.SetString("WinningTeam", "Team 4");
            PlayerPrefs.SetInt("CorrectAnswerByTeam4", TotalScoreByTeam4);
            PlayerPrefs.SetInt("WrongAnswerByTeam4", wrongAnswerByTeam4);
        }


        SetWinner_TieTagInRoundSection();
        Open_Winner_TieTagRoundSection();
        GameOverMenu.instance.Group_GetCorrectWrongAnswerForTexts();

    }

    #endregion

    #region Data Saving to Dictionary

    public void createDictionaryForTeamsCorrectAnswers()
    {
        for (int i = 1; i <= selectedTeamValue; i++)
        {
            string teamName = "Team" + i;
            Debug.Log("Teams List Created" + teamName);
            List<string> teamList = new List<string>();
            teams.Add(teamName, teamList);
        }

    }

    public void AddDataToDictionaryTeams_CorrectAnswers(string key, string data)
    {
        if (teams.ContainsKey(key))
        {
            if (!teams[key].Contains(data))
            {
                teams[key].Add(data);

                //CorrectAnswerGivenByTeams.Add(data);
                switch (key)
                {
                    case "Team1":
                        Temp_TeamList1.Add(data);
                        ResetRoundCorrectAnswerList.Add(data);
                        switch (currentRound)
                        {
                            case 1:
                                correctAnswerGivenT1R1 += 1;
                                break;
                            case 2:
                                correctAnswerGivenT1R2 += 1;
                                break;
                            case 3:
                                correctAnswerGivenT1R3 += 1;
                                break;
                            case 4:
                                correctAnswerGivenT1R4 += 1;
                                break;
                            case 5:
                                correctAnswerGivenT1R5 += 1;
                                break;
                            case 6:
                                correctAnswerGivenT1R6 += 1;
                                break;
                            case 7:
                                correctAnswerGivenT1R7 += 1;
                                break;

                        }
                        break;


                    case "Team2":
                        Temp_TeamList2.Add(data);
                        ResetRoundCorrectAnswerList.Add(data);
                        switch (currentRound)
                        {
                            case 1:
                                correctAnswerGivenT2R1 += 1;
                                break;
                            case 2:
                                correctAnswerGivenT2R2 += 1;
                                break;
                            case 3:
                                correctAnswerGivenT2R3 += 1;
                                break;
                            case 4:
                                correctAnswerGivenT2R4 += 1;
                                break;
                            case 5:
                                correctAnswerGivenT2R5 += 1;
                                break;
                            case 6:
                                correctAnswerGivenT2R6 += 1;
                                break;
                            case 7:
                                correctAnswerGivenT2R7 += 1;
                                break;

                        }
                        break;


                    case "Team3":
                        Temp_TeamList3.Add(data);
                        ResetRoundCorrectAnswerList.Add(data);
                        switch (currentRound)
                        {
                            case 1:
                                correctAnswerGivenT3R1 += 1;
                                break;
                            case 2:
                                correctAnswerGivenT3R2 += 1;
                                break;
                            case 3:
                                correctAnswerGivenT3R3 += 1;
                                break;
                            case 4:
                                correctAnswerGivenT3R4 += 1;
                                break;
                            case 5:
                                correctAnswerGivenT3R5 += 1;
                                break;
                            case 6:
                                correctAnswerGivenT3R6 += 1;
                                break;
                            case 7:
                                correctAnswerGivenT3R7 += 1;
                                break;

                        }
                        break;


                    case "Team4":
                        Temp_TeamList4.Add(data);
                        ResetRoundCorrectAnswerList.Add(data);
                        switch (currentRound)
                        {
                            case 1:
                                correctAnswerGivenT4R1 += 1;
                                break;
                            case 2:
                                correctAnswerGivenT4R2 += 1;
                                break;
                            case 3:
                                correctAnswerGivenT4R3 += 1;
                                break;
                            case 4:
                                correctAnswerGivenT4R4 += 1;
                                break;
                            case 5:
                                correctAnswerGivenT4R5 += 1;
                                break;
                            case 6:
                                correctAnswerGivenT4R6 += 1;
                                break;
                            case 7:
                                correctAnswerGivenT4R7 += 1;
                                break;

                        }
                        break;
                }
            }
            else
            {
                Debug.Log("Data already in List");

            }

        }
        else
        {
            Debug.Log("No List found for this key");
        }
        //ShowDataStoredInDictionaryTeams(key);

    }

    public void AddDataToDictionaryTeams_WrongAnswers(string key, string data)
    {
        if (teams.ContainsKey(key))
        {
            if (!teams[key].Contains(data))
            {
                teams[key].Add(data);

                //CorrectAnswerGivenByTeams.Add(data);
                switch (key)
                {
                    case "Team1":
                        Temp_TeamList1_Wrong.Add(data);
                        ResetRoundWrongAnswerList.Add(data);
                        switch (currentRound)
                        {
                            case 1:
                                wrongAnswerGivenT1R1 += 1;
                                break;
                            case 2:
                                wrongAnswerGivenT1R2 += 1;
                                break;
                            case 3:
                                wrongAnswerGivenT1R3 += 1;
                                break;
                            case 4:
                                wrongAnswerGivenT1R4 += 1;
                                break;
                            case 5:
                                wrongAnswerGivenT1R5 += 1;
                                break;
                            case 6:
                                wrongAnswerGivenT1R6 += 1;
                                break;
                            case 7:
                                wrongAnswerGivenT1R7 += 1;
                                break;

                        }
                        break;


                    case "Team2":
                        Temp_TeamList2_Wrong.Add(data);
                        ResetRoundWrongAnswerList.Add(data);
                        switch (currentRound)
                        {
                            case 1:
                                wrongAnswerGivenT2R1 += 1;
                                break;
                            case 2:
                                wrongAnswerGivenT2R2 += 1;
                                break;
                            case 3:
                                wrongAnswerGivenT2R3 += 1;
                                break;
                            case 4:
                                wrongAnswerGivenT2R4 += 1;
                                break;
                            case 5:
                                wrongAnswerGivenT2R5 += 1;
                                break;
                            case 6:
                                wrongAnswerGivenT2R6 += 1;
                                break;
                            case 7:
                                wrongAnswerGivenT2R7 += 1;
                                break;

                        }
                        break;


                    case "Team3":
                        Temp_TeamList3_Wrong.Add(data);
                        ResetRoundWrongAnswerList.Add(data);
                        switch (currentRound)
                        {
                            case 1:
                                wrongAnswerGivenT3R1 += 1;
                                break;
                            case 2:
                                wrongAnswerGivenT3R2 += 1;
                                break;
                            case 3:
                                wrongAnswerGivenT3R3 += 1;
                                break;
                            case 4:
                                wrongAnswerGivenT3R4 += 1;
                                break;
                            case 5:
                                wrongAnswerGivenT3R5 += 1;
                                break;
                            case 6:
                                wrongAnswerGivenT3R6 += 1;
                                break;
                            case 7:
                                wrongAnswerGivenT3R7 += 1;
                                break;

                        }
                        break;


                    case "Team4":
                        Temp_TeamList4_Wrong.Add(data);
                        ResetRoundWrongAnswerList.Add(data);
                        switch (currentRound)
                        {
                            case 1:
                                wrongAnswerGivenT4R1 += 1;
                                break;
                            case 2:
                                wrongAnswerGivenT4R2 += 1;
                                break;
                            case 3:
                                wrongAnswerGivenT4R3 += 1;
                                break;
                            case 4:
                                wrongAnswerGivenT4R4 += 1;
                                break;
                            case 5:
                                wrongAnswerGivenT4R5 += 1;
                                break;
                            case 6:
                                wrongAnswerGivenT4R6 += 1;
                                break;
                            case 7:
                                wrongAnswerGivenT4R7 += 1;
                                break;

                        }
                        break;
                }
            }
            else
            {
                Debug.Log("Data already in List");

            }

        }
        else
        {
            Debug.Log("No List found for this key");
        }
    }


    public void ShowDataStoredInDictionaryTeams(string key)
    {
        if (teams.ContainsKey(key))
        {
            List<string> dataList = teams[key];
            PlayerPrefs.SetInt(key, dataList.Count);
            Debug.Log("Lenght of Team:" + key + ": " + PlayerPrefs.GetInt(key));

            foreach (string str in dataList)
            {
                Debug.Log("Key:" + key + " Data: " + str);
            }

        }
    }


    #endregion

    #region Correct/Wrong Answers Functionality.
    public void isCorrectAnswer()
    {
        if(PlayerPrefs.GetString("GameType")=="GroupVersus")
        {
            //Handles correct answer for Group Versus.
            string teamName = "Team" + currentTeam;
            AddDataToDictionaryTeams_CorrectAnswers(teamName, currentWord);
            if (!correctImageShown)
            {
                soundManager.PlayCorrectAnswerSound();
                StartCoroutine(Group_Team_ShowCorrectAnswerPanel());
            }
            Group_Team_showNextWord();

        }

        if(PlayerPrefs.GetString("GameType")=="SingleQuickPlay")
        {
            //Handles correct answer for Single QuickPlay.
            if (!Single_QuickPlay_CorrectAnswerGiven.Contains(currentWord))
            {
                Single_QuickPlay_CorrectAnswerGiven.Add(currentWord);
                soundManager.PlayCorrectAnswerSound();
                StartCoroutine(Single_QuickPlay_ShowCorrectAnswerPanel());
            }
            else
            {
                soundManager.PlayCorrectAnswerSound();
                StartCoroutine(Single_QuickPlay_ShowCorrectAnswerPanel());
            }
        }
    }
    public void isWrong_PassAnswer()
    {
        if(PlayerPrefs.GetString("GameType")=="GroupVersus")
        {
            //Handles wrong answers for Group Versus.
            string teamName = "Team" + currentTeam;
            AddDataToDictionaryTeams_WrongAnswers(teamName, currentWord);
            if (!correctImageShown)
            {
                soundManager.PlayWrongAnswerSound();
                StartCoroutine(Group_Team_ShowPassAnswerPanel());
            }
            Group_Team_showNextWord();
        }
        if (PlayerPrefs.GetString("GameType") == "SingleQuickPlay")
        {
            //Handles wrong answers for Single QuickPlay.
            if (!Single_QuickPlay_WrongAnswerGiven.Contains(currentWord))
            {
                Single_QuickPlay_WrongAnswerGiven.Add(currentWord);
            }
            StartCoroutine(Single_QuickPlay_ShowPassAnswerPanel());
            soundManager.PlayWrongAnswerSound();
        }
    }

    #endregion

    #region Miscellenous Functions.
    public void getCategoryWords()
    {
        for (int i = 0; i < SubcategoryFetcher.subCatLists.Count; i++)
        {
            WordList.Add(SubcategoryFetcher.subCatLists[i].name);
        }
    }

    public bool isRoundEnded()
    {
        return roundEnded;
    }

    public void InstatiateRestRoundObjects()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Low Res UI.
            switch (currentTeam)
            {
                case 1:
                    switch (currentRound)
                    {
                        case 1:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";

                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();

                            }
                            /*
                            for (int i = 0; i < ResetRoundCorrectAnswerList.Count; i++)
                            {
                                GameObject obj = Instantiate(ResetRound_Word);
                                obj.gameObject.tag = "ResetRounds";
                                obj.transform.position = ResetRoundContent.transform.position;
                                obj.transform.parent = ResetRoundContent.transform;
                                obj.GetComponent<Text>().text = ResetRoundCorrectAnswerList[i];
                            }
                            for (int i = 0; i < ResetRoundWrongAnswerList.Count; i++)
                            {
                                GameObject obj = Instantiate(ResetRound_Word);
                                obj.gameObject.tag = "ResetRounds";
                                obj.transform.position = ResetRoundContent.transform.position;
                                obj.transform.parent = ResetRoundContent.transform;
                                obj.GetComponent<Text>().text = ResetRoundWrongAnswerList[i];
                                Color c = obj.GetComponent<Text>().color;
                                c.a = 0.5f;
                                obj.GetComponent<Text>().color = c;
                            }
                            */
                            break;

                        case 2:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                          
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 3:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();

                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }

                            break;
                        case 4:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                   
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 5:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                       
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 6:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                      
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                CorrectAnswerGivenInRoundResultText.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 7:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
       
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                CorrectAnswerGivenInRoundResultText.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }

                            break;
                    }
                    break;

                case 2:
                    switch (currentRound)
                    {
                        case 1:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                   
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 2:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                  
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 3:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                 
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 4:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                      
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 5:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                  
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 6:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                     
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 7:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                      
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                    }
                    break;

                case 3:
                    switch (currentRound)
                    {
                        case 1:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                     
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 2:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                    
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 3:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                    
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 4:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                        
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 5:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                         
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 6:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
          
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 7:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                   
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                    }
                    break;

                case 4:
                    switch (currentRound)
                    {
                        case 1:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
          
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 2:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 3:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                 
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 4:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                         
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 5:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                          
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 6:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 7:
                            low_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                     
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                low_NoWordAtResetRound.SetActive(true);
                                low_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                low_resetRoundPanel_correctAnswers.text = "0";
                                low_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                low_NoWordAtResetRound.SetActive(false);
                                low_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                low_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                    }
                    break;
            }
        }
        else
        {
            //High Res UI.
            switch (currentTeam)
            {
                case 1:
                    switch (currentRound)
                    {
                        case 1:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                  
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";

                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();

                            }
                            /*
                            for (int i = 0; i < ResetRoundCorrectAnswerList.Count; i++)
                            {
                                GameObject obj = Instantiate(ResetRound_Word);
                                obj.gameObject.tag = "ResetRounds";
                                obj.transform.position = ResetRoundContent.transform.position;
                                obj.transform.parent = ResetRoundContent.transform;
                                obj.GetComponent<Text>().text = ResetRoundCorrectAnswerList[i];
                            }
                            for (int i = 0; i < ResetRoundWrongAnswerList.Count; i++)
                            {
                                GameObject obj = Instantiate(ResetRound_Word);
                                obj.gameObject.tag = "ResetRounds";
                                obj.transform.position = ResetRoundContent.transform.position;
                                obj.transform.parent = ResetRoundContent.transform;
                                obj.GetComponent<Text>().text = ResetRoundWrongAnswerList[i];
                                Color c = obj.GetComponent<Text>().color;
                                c.a = 0.5f;
                                obj.GetComponent<Text>().color = c;
                            }
                            */
                            break;

                        case 2:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                    
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 3:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }

                            break;
                        case 4:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                          
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 5:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 6:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                          
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                CorrectAnswerGivenInRoundResultText.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 7:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                          
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                CorrectAnswerGivenInRoundResultText.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }

                            break;
                    }
                    break;

                case 2:
                    switch (currentRound)
                    {
                        case 1:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                       
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 2:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 3:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 4:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 5:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 6:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 7:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                    }
                    break;

                case 3:
                    switch (currentRound)
                    {
                        case 1:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                          
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 2:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                           
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 3:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                      
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 4:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
              
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 5:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                    
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 6:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                       
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 7:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                     
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                    }
                    break;

                case 4:
                    switch (currentRound)
                    {
                        case 1:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                            
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 2:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 3:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 4:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 5:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 6:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                        case 7:
                            high_RoundResultText.text = ("Team : " + currentTeam + " Round : " + currentRound).ToString();
                            if (ResetRoundCorrectAnswerList.Count == 0 && ResetRoundWrongAnswerList.Count == 0)
                            {
                                high_NoWordAtResetRound.SetActive(true);
                                high_NoWordAtResetRound.GetComponent<Text>().text = "No Words Found!";
                                high_resetRoundPanel_correctAnswers.text = "0";
                                high_resetRoundPanel_WrongAnswers.text = "0";
                            }
                            else
                            {
                                high_NoWordAtResetRound.SetActive(false);
                                high_resetRoundPanel_correctAnswers.text = ResetRoundCorrectAnswerList.Count.ToString();
                                high_resetRoundPanel_WrongAnswers.text = ResetRoundWrongAnswerList.Count.ToString();
                            }
                            break;
                    }
                    break;
            }
        }
       
    }

    #endregion

    #region Time calculation Functionality.
    public void UpdateTimerText()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            string timeString;
            if (timeRemaining < 60)
            {
                timeString = string.Format("{0:00}:{1:00}" + " Secs", minutes, seconds);
                low_timeText.text = timeString;
            }
            else
            {
                timeString = string.Format("{0:00}:{1:00}" + " Mins", minutes, seconds);
                low_timeText.text = timeString;
            }
        }
        else
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            string timeString;
            if (timeRemaining < 60)
            {
                timeString = string.Format("{0:00}:{1:00}" + " Secs", minutes, seconds);
                high_timeText.text = timeString;
            }
            else
            {
                timeString = string.Format("{0:00}:{1:00}" + " Mins", minutes, seconds);
                high_timeText.text = timeString;
            }
        }

    }

    #endregion

    public void CloseGameSections()
    {
        PlayerPrefs.SetInt("GameStarted", 0);
        HomeManager.instance.loadingObj.SetActive(true);
        LevelLoader.instance.ReloadLoadingTransition();
    }

    public void ClosingCharadeDetailPanel()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            if (low_Eng_CharadeDetails.activeSelf)
            {
                low_Eng_CharadeDetails.SetActive(false);
            }
        }
        else
        {
            if (high_Eng_CharadeDetails.activeSelf)
            {
                high_Eng_CharadeDetails.SetActive(false);
            }
        }
       
    }


    public void CloseResetRoundPanel()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            low_ResetRoundPanel.SetActive(false);
            roundEnded = true;
            low_groupSection.SetActive(true);
            ResetRoundCorrectAnswerList.Clear();
            ResetRoundWrongAnswerList.Clear();
            low_NoWordAtResetRound.SetActive(false);
            low_gameWhitePanel.SetActive(false);
            PlayerPrefs.SetInt("GameStarted", 0);
        }
        else
        {
            high_ResetRoundPanel.SetActive(false);
            roundEnded = true;
            high_groupSection.SetActive(true);
            ResetRoundCorrectAnswerList.Clear();
            ResetRoundWrongAnswerList.Clear();
            high_NoWordAtResetRound.SetActive(false);
            high_gameWhitePanel.SetActive(false);
            PlayerPrefs.SetInt("GameStarted", 0);
        }

    }


    
   

    public void CloseScoreDetailsPanel()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            low_Group_Team_ScoreCardPanel.GetComponent<Animator>().SetBool("IsOpen", false);
            canCloseWinnerTag = true;
        }
        else
        {
            high_Group_Team_ScoreCardPanel.GetComponent<Animator>().SetBool("IsOpen", false);
            canCloseWinnerTag = true;
        }
        StartCoroutine(closeScoreDetailsPanel());
    }
    IEnumerator closeScoreDetailsPanel()
    {
        yield return new WaitForSeconds(1);
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            low_Group_Team_ScoreCardPanel.SetActive(false);
        }
        else
        {
            high_Group_Team_ScoreCardPanel.SetActive(false);
        }
    }

    public void StartTimer()
    {
        isCounting = true;
    }

    public void StopTimer()
    {
        isCounting = false;
    }

    public void UpdateTimeForCatDetailsPanel()
    {
        timeRemaining = totalTime;
        UpdateTimerText();
    }

    public void AddTime(float timeToAdd)
    {
        totalTime += timeToAdd;
        totalTime = Mathf.Clamp(totalTime, Minimumtime, Maximumtime);
        timeRemaining = totalTime;
        UpdateTimerText();
    }
    public void RemoveTime(float timeToRemove)
    {
        totalTime -= timeToRemove;
        totalTime = Mathf.Clamp(totalTime, Minimumtime, Maximumtime);
        timeRemaining = totalTime;
        UpdateTimerText();
    }

   



    IEnumerator CloseCharadeDetailAfterFewSec()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            //Low Res UI.
            yield return new WaitForSeconds(2f);
            low_Eng_CharadeDetails.SetActive(false);
            
        }
        else
        {
            //High Res UI.
            yield return new WaitForSeconds(2f);
            high_Eng_CharadeDetails.SetActive(false);
        }

    }

    IEnumerator CloseGameoverMenuAfterFewSec()
    {
        if(PlayerPrefs.GetString("UIType")=="lowRes")
        {
            yield return new WaitForSeconds(1);
            low_GameOverPanel.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(1);
            high_GameOverPanel.SetActive(false);
        }

    }
}
