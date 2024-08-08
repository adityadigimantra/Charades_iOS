/*
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class CameraRecording : MonoBehaviour
{
    public RawImage Group_QuickPlay_RawImage;
    public RawImage Group_Teams_RawImage;
    private  WebCamTexture frontCameraTexture = null;
    public GameObject Group_QuickPlay_CameraFeedPanel;
    public GameObject Group_Teams_CameraFeedPanel;

    [Header("Buttons To Toggle")]
    public GameObject Group_QuickPlay_CameraOFF;
    public GameObject Group_QuickPlay_CameraON;

    public GameObject Group_Teams_CameraON;
    public GameObject Group_Teams_CameraOFF;
   
    private void Start()
    {
        if(Application.platform==RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
            }
        }

    }

    public void OpenCameraDevice()
    {
        if(PlayerPrefs.GetInt("GameMode")==2)
        {
            if(PlayerPrefs.GetString("GameType")=="GroupQuickPlay")
            {
                Group_QuickPlay_CameraON.SetActive(false);
                Group_QuickPlay_CameraOFF.SetActive(true);
                WebCamDevice[] devices = WebCamTexture.devices;
                //For Unity Editor

                //if(devices.Length==0)
                //{
                //    return;
                //}
                //frontCameraTexture = new WebCamTexture(devices[0].name);

                //For Mobile
                foreach (WebCamDevice device in devices)
                {
                    if (device.isFrontFacing)
                    {
                        frontCameraTexture = new WebCamTexture(device.name);
                    }
                }
                // Start camera feed from the first device
                Group_QuickPlay_CameraFeedPanel.SetActive(true);
                Group_QuickPlay_RawImage.texture = frontCameraTexture;
                frontCameraTexture.Play();
            }
            else
            {
                Group_Teams_CameraON.SetActive(false);
                Group_Teams_CameraOFF.SetActive(true);
                WebCamDevice[] devices = WebCamTexture.devices;
                //For Unity Editor

                //if(devices.Length==0)
                //{
                //    return;
                //}
                //frontCameraTexture = new WebCamTexture(devices[0].name);

                //For Mobile
                foreach (WebCamDevice device in devices)
                {
                    if (device.isFrontFacing)
                    {
                        frontCameraTexture = new WebCamTexture(device.name);
                    }
                }
                // Start camera feed from the first device
                Group_Teams_CameraFeedPanel.SetActive(true);
                Group_Teams_RawImage.texture = frontCameraTexture;
                frontCameraTexture.Play();
            }
        }
        
    }

    public void CloseCameraDevice()
    {

        if(PlayerPrefs.GetInt("GameMode")==2)
        {
            if(PlayerPrefs.GetString("GameType")=="GroupQuickPlay")
            {
                Debug.Log(frontCameraTexture);
                if(frontCameraTexture!=null)
                {
                    Group_QuickPlay_CameraON.SetActive(true);
                    Group_QuickPlay_CameraOFF.SetActive(false);
                    Group_QuickPlay_CameraFeedPanel.SetActive(false);
                    frontCameraTexture.Stop();
                }
            }
            else
            {
                Group_Teams_CameraON.SetActive(true);
                Group_Teams_CameraOFF.SetActive(false);
                Group_Teams_CameraFeedPanel.SetActive(false);
                if(frontCameraTexture!=null)
                {
                    frontCameraTexture.Stop();
                }
                
            }
        }
        
    }

}
*/
