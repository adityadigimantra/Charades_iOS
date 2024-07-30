/*
// Define flags to control the functionality
private bool isCorrectTiltInvoked = false;
private bool canShowNextWord = true;

public void tiltController()
{
    DeltaYText.text = Input.acceleration.z.ToString();

    if (Input.acceleration.z >= (tiltThreshold + Hysteresis))
    {
        if (!isCorrectTiltInvoked)
        {
            OnCorrectTilt.Invoke();
            isCorrectTiltInvoked = true;
        }
    }

    if (Input.acceleration.z <= 0.9)
    {
        isCorrectTiltInvoked = false;
    }

    if (Input.acceleration.z <= (-tiltThreshold - Hysteresis))
    {
        wrongTiltDetected = true;
    }

    if (wrongTiltDetected && !functionInvoked)
    {
        OnWrongTilt.Invoke();
    }

    if (Input.acceleration.z >= -0.9)
    {
        wrongTiltDetected = false;
    }
}

public void Group_QuickPlay_showNextWord()
{
    if (canShowNextWord && Input.acceleration.z <= 0)
    {
        // Reset canShowNextWord when acceleration becomes 0
        canShowNextWord = false;
    }

    if (!canShowNextWord && Input.acceleration.z >= 1)
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
                return;
            }
            do
            {
                nextWord = WordList[Random.Range(0, WordList.Count)];
            }
            while (shownWords.Contains(nextWord));

            Group_QuickPlay_WordText.text = nextWord;
            currentWord = nextWord;
            shownWords.Add(nextWord);
        }

        canShowNextWord = true; // Allow showing the next word again
    }
}


 */
