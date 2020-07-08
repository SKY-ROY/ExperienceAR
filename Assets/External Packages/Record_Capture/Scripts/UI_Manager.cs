using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public RecordManager recordmanager;
    public Button recordButton;
    public Button saveButton;

    public void Start()
    {
        if (recordButton && saveButton)
        {
            saveButton.gameObject.SetActive(false);
        }
    }
    
    public void PermisionPrompt()
    {
        recordmanager.StartRecord();
        recordmanager.StopRecord();
    }

    public void Record()
    {
        if(recordButton && saveButton)
        {
            recordButton.gameObject.SetActive(false);
            saveButton.gameObject.SetActive(true);
        }
        //recordButton.interactable = false;
        //saveButton.interactable = true;
        recordmanager.StartRecord();
    }

    public void Save()
    {
        if (recordButton && saveButton)
        {
            saveButton.gameObject.SetActive(false);
            recordButton.gameObject.SetActive(true);
        }
        //recordButton.interactable = true;
        //saveButton.interactable = false;
        recordmanager.StopRecord();
    }

    public void Capture()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        Debug.Log("Permission results: " + NativeGallery.SaveImageToGallery(ss, "GalleryTest", "Image.png"));

        Destroy(ss);
    }
}
