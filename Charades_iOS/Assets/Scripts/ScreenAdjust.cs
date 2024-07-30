/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdjust : MonoBehaviour
{
    public int targetFrameRate = 30;
    public bool scaleDown = true;
    public int scaleResolution = 1080;


    private void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
        if(screenHeight>scaleResolution)
        {
            float scaleFactor = screenHeight / scaleResolution;
            screenWidth = (int)(screenWidth / scaleFactor);
            screenHeight = (int)(screenHeight / scaleFactor);
        }
        Screen.SetResolution(screenWidth, screenHeight, true);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
*/
using UnityEngine;
using UnityEngine.UI;

public class ScreenAdjust : MonoBehaviour
{
    public float referenceDPI = 160f;
    public float referenceWidth = 1080f;
    public float referenceHeight = 2400;

    private CanvasScaler canvasScaler;

    private void Awake()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        AdjustCanvasScale();
    }

    private void AdjustCanvasScale()
    {
        float screenDPI = Screen.dpi;
        float widthRatio = Screen.width / referenceWidth;
        float heightRatio = Screen.height / referenceHeight;
        float scaleFactor = Mathf.Min(widthRatio, heightRatio) * (screenDPI / referenceDPI);

        canvasScaler.scaleFactor = scaleFactor;
    }
}
