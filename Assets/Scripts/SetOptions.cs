using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class SetOptions : MonoBehaviour
{
    [SerializeField] private GameObject kayak;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Setting;

    private float volumeValue;
    private float VerticalSensitivity;
    private float HorizontalSensitivity;

    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] availableResolutions;
    private Resolution selectedResolution;

    void Start()
    {
        SetupResolutionDropdown();
    }

    public void SetGlobalSoundVolume(float volume)
    {
        volumeValue = volume;
    }

    public void ToggleMute(bool mute)
    {
        AudioListener.volume = mute ? 0f : 1f;
    }

    public void SetMouseVerticalSensitivity(float verticalSensitivity) 
    {
        VerticalSensitivity = verticalSensitivity;
    }

    public void SetMouseHorizontalSensitivity(float horizontalSensitivity)
    {
        HorizontalSensitivity = horizontalSensitivity;
    }

    public void SetScreenResolution(int resolutionX, int resolutionY, bool isFullScreen)
    {
        Screen.SetResolution(resolutionX, resolutionY, isFullScreen);
    }
    public void SetBasicResolution(bool isFullScreen)
    {
        Resolution currentResolution = Screen.currentResolution;
        Screen.SetResolution(currentResolution.width, currentResolution.height, isFullScreen);
    }

    public void SetBrightness(float brightness) 
    {
        Screen.brightness = brightness;
    }

    public void ResolutionDropbox()
    {
        int selectedResolutionIndex = resolutionDropdown.value;
        selectedResolution = availableResolutions[selectedResolutionIndex];
    }

    public void MainMenuButton()
    {
        MainMenu.SetActive(true);
        Setting.SetActive(false);
    }

    public void ApplySettings()
    {
        AudioListener.volume = volumeValue;

        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);

        KayakController kayakController = kayak.GetComponent<KayakController>();
        kayakController.mouseHorizontalSensitivity = HorizontalSensitivity;
        kayakController.mouseVerticalSensitivity = VerticalSensitivity;

        MainMenuButton();
    }

    void SetupResolutionDropdown()
    {
        Debug.Log("Setting up resolution dropdown...");

        resolutionDropdown.ClearOptions();
        resolutionDropdown.onValueChanged.RemoveAllListeners();

        availableResolutions = Screen.resolutions;

        var uniqueOptions = new HashSet<string>();
        var filteredResolutions = new List<Resolution>();

        foreach (Resolution res in availableResolutions)
        {
            string option = $"{res.width} x {res.height}";
            if (uniqueOptions.Add(option)) // Only add unique resolutions
            {
                filteredResolutions.Add(res);
            }
        }

        availableResolutions = filteredResolutions.ToArray();

        var options = new List<string>(uniqueOptions);
        resolutionDropdown.AddOptions(options);

        Debug.Log($"Added {options.Count} unique resolutions to the dropdown.");

        // Set default resolution
        int currentResolutionIndex = 0;
        for (int i = 0; i < availableResolutions.Length; i++)
        {
            if (availableResolutions[i].width == Screen.currentResolution.width &&
                availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                break;
            }
        }

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.onValueChanged.AddListener(delegate { ResolutionDropbox(); });

        selectedResolution = availableResolutions[currentResolutionIndex];
    }
}
