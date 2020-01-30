using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; 

    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    private TMP_Dropdown difficultyDropdown;

    public GameObject GameManager;


    void Start () 
    {
        resolutions = Screen.resolutions; //Finds the different res for the computer 

        resolutionDropdown.ClearOptions(); //clears the drop down at the start 

        List<string> options = new List<string>(); //creates list of strings for options of res

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) //loop each element
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //create a nicely formatted string that displays res

            options.Add(option); //adds to options list

            if ((resolutions[i].width == Screen.currentResolution.width) && (resolutions[i].height == Screen.currentResolution.height)) //checks resolution boundary to make sure its not bigger than screen
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options); //adds these to dropdown list
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetDifficulty()
    {
        GameManager.GetComponent<GameManager>().difficulty = GameObject.Find("DifficultyDropDown").GetComponent<TMP_Dropdown>().value;
        Debug.Log(GameManager.GetComponent<GameManager>().difficulty);
    }

    public void setFullscreen (bool isFullscreen)
    {
        Debug.Log("is full screen");
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
