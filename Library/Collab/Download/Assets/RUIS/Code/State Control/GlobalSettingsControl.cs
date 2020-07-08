﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.SceneManagement;

public class GlobalSettingsControl : MonoBehaviour
{
    public bool musicBool = true;
    public bool sfxBool = true;
    public bool loggedInBool = false;
    public string prefabTitle;

    //public bool portalBool = true;
    //public int qualityLevelIndex;
    //public float volumeVal;
    //public int highScoreCount;

    //public static int size;
    //public Toggle[] toggleArray = new Toggle[size];//Music, SFX, Portal.
    //public Dropdown graphicsVal;
    //public Slider volumeSlider;
    public Toggle loggedInToggle;
    public Toggle loggedInToggleDup;

    public AudioMixer audioMixer;

    private float previousVol;

    private void Start()
    {
        Time.timeScale = 1;//flush all pause states and reset to normal time scale
        IsFirstTime();
        LoadState();
        if (musicBool && sfxBool)
        {
            GetComponent<AudioSource>().Play();
        }
    }
    private void Update()
    {
        //graphicsVal.value = qualityLevelIndex;
        //toggleArray[0].isOn = musicBool;
        //toggleArray[1].isOn = sfxBool;
        //toggleArray[2].isOn = portalBool;
        //volumeSlider.value = volumeVal;
        SceneRespectiveUpdate();
    }
    private void SceneRespectiveUpdate()
    {
        if(GameObject.Find("StartSceneController"))
        {
            loggedInToggle.isOn = loggedInBool;
            loggedInToggleDup.isOn = loggedInBool;
        }
    }
    /*
    public void HighScoreRefresh()
    {
        if(gameObject.GetComponent<FPSSceneControl>())
        {
            highScoreCount = gameObject.GetComponent<FPSSceneControl>().highScore;
            SaveState();
            //Debug.Log("HS: " + highScoreCount);
        }
    }
    */
    /*
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityLevelIndex = qualityIndex;
        SaveState();
    }
    */
    public void SetMusic(bool argVal)
    {
        musicBool = argVal;
        if (musicBool)
        {
            GetComponent<AudioSource>().Play();
        }
        else if (!musicBool)
        {
            GetComponent<AudioSource>().Stop();
        }
        SaveState();
    }
    public void SetSFX(bool argVal)
    {
        sfxBool = argVal;
        if (!sfxBool)
        {
            audioMixer.GetFloat("Volume", out previousVol);
            audioMixer.SetFloat("Volume", -80);
            GetComponent<AudioSource>().Stop();
        }
        else if (sfxBool)
        {
            audioMixer.SetFloat("Volume", previousVol);
            GetComponent<AudioSource>().Play();
        }
        SaveState();
    }
    public void SetLogIn(bool argVal)
    {
        loggedInBool = argVal;
        SaveState();
    }
    /*
    public void SetVolume(float argvolume)
    {
        audioMixer.SetFloat("Volume", argvolume);
        volumeVal = argvolume;
        SaveState();
    }
    */
    public void SaveState()
    {
        SaveSystem.SaveState(this);
    }
    public void LoadState()
    {
        StateData data = SaveSystem.LoadState();

        sfxBool = data.sfx;
        musicBool = data.music;
        loggedInBool = data.loggedIn;
        prefabTitle = data.prefabName;
        //portalBool = data.portal;
        //qualityLevelIndex = data.qualityLevel;
        //volumeVal = data.volume;
        //highScoreCount = data.highScore;
    }
    public void IsFirstTime()
    {
        string path1 = Application.persistentDataPath + "/this.Sett";

        if (!File.Exists(path1))
        {
            Debug.Log("First Time Launch");
            SaveState();
        }
        else
            Debug.Log("Not First Time");
    }
    
}