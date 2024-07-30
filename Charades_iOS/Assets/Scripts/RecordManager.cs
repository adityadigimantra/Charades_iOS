using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Video;

public class RecordManager: MonoBehaviour
{
    public RawImage rawImage;
    public int frameRate = 30;
    private bool isRecording = false;
    public string videoFilePath;
    private List<Texture2D> frameTextures = new List<Texture2D>();
    public GameObject cameraFeedPanel;
    private WebCamTexture webCamTexture;
    public float maxRecordingTime = 120f;
    private void Start()
    {
        videoFilePath = Path.Combine(Application.persistentDataPath, "recording.mp4");
        webCamTexture = new WebCamTexture();
        rawImage.texture = webCamTexture;
        webCamTexture.Play();
    }

    public void StartRecording()
    {
        cameraFeedPanel.SetActive(true);
        if (isRecording)
        {
            return;
        }
        else
        {
            isRecording = true;
            StartCoroutine(RecordFrames());
        }
    }

    IEnumerator RecordFrames()
    {
        float startTime = Time.time;

        while (isRecording && Time.time - startTime <= maxRecordingTime)
        {
            yield return new WaitForEndOfFrame();
            RenderTexture renderTexture = RenderTexture.GetTemporary(Screen.width, Screen.height);
            RenderTexture.active = renderTexture;
            rawImage.texture = renderTexture;
            rawImage.material.mainTexture = renderTexture;
            Texture2D frameTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            frameTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            frameTexture.Apply();
            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(renderTexture);
            frameTextures.Add(frameTexture);
        }

        SaveVideo();
    }

    private void SaveVideo()
    {
        //using (var encoder = new VideoPlayer(videoFilePath, Screen.width, Screen.height, frameRate))
        //{
        //    foreach (var texture in frameTextures)
        //    {
        //        encoder.AddFrame(texture);
        //        Destroy(texture);
        //    }
        //}

        var videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.url = videoFilePath;
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        videoPlayer.Play();
    }

    public void StopRecording()
    {
        isRecording = false;
        cameraFeedPanel.SetActive(false);
    }
}
