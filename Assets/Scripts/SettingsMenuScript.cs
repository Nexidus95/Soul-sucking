using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuScript : MonoBehaviour
{
    public AudioMixer audiomixer;
    public TMPro.TMP_Dropdown ResolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        int CurrentResolutionIndex = 0;
        resolutions = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(Option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = CurrentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetMasterVolume (float volume)
    {
        audiomixer.SetFloat("MasterParam", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audiomixer.SetFloat("MusicParam", volume);
    }
    public void SetGameVolume(float volume)
    {
        audiomixer.SetFloat("GameParam", volume);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
