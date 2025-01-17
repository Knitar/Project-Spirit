using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDD;

    Resolution[] resolutions;

    public void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height}).Distinct().ToArray();
        resolutionDD.ClearOptions();

        List<string> options = new List<string>();

        int IndexResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                IndexResolution = i;
            }
        }

        resolutionDD.AddOptions(options);
        resolutionDD.value = IndexResolution;
        resolutionDD.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Musique",volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("Effets",volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
