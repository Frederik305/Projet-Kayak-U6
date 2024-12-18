using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetOptions : MonoBehaviour
{
    //[SerializeField] private GameObject kayak;
    [SerializeField] private GameObject previousCanva;
    [SerializeField] private GameObject Setting;

    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Slider sliderVerticalSensitivity;
    [SerializeField] private Slider sliderHorizontalSensitivity;

    private float volumeValue = 1f;
    private float VerticalSensitivity = 110f;
    private float HorizontalSensitivity = 180f;

    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] availableResolutions;
    private Resolution selectedResolution;
    private KayakController kayakController;

    void Start()
    {
        sliderVolume.value = volumeValue;
        sliderVerticalSensitivity.value = VerticalSensitivity;
        sliderHorizontalSensitivity.value = HorizontalSensitivity;

        AudioListener.volume = volumeValue;
        kayakController.mouseHorizontalSensitivity = HorizontalSensitivity;
        kayakController.mouseVerticalSensitivity = VerticalSensitivity;
    }

    public void SetGlobalSoundVolume(float volume)
    {
        volumeValue = volume;
    }

    public void ToggleMute(bool mute)
    {
        AudioListener.volume = mute ? 0f : volumeValue;
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

    public void PreviousCanvas()
    {
        previousCanva.SetActive(true);
        Setting.SetActive(false);
    }

    public void ApplySettings()
    {
        AudioListener.volume = volumeValue;

        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);

        kayakController.mouseHorizontalSensitivity = HorizontalSensitivity;
        kayakController.mouseVerticalSensitivity = VerticalSensitivity;

        SaveSettings();
        PreviousCanvas();
    }

    public void SetupResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        resolutionDropdown.onValueChanged.RemoveAllListeners();

        availableResolutions = Screen.resolutions;

        var uniqueOptions = new HashSet<string>();
        var filteredResolutions = new List<Resolution>();

        foreach (Resolution res in availableResolutions)
        {
            string option = $"{res.width} x {res.height}";
            if (uniqueOptions.Add(option))
            {
                filteredResolutions.Add(res);
            }
        }

        availableResolutions = filteredResolutions.ToArray();

        var options = new List<string>(uniqueOptions);
        resolutionDropdown.AddOptions(options);

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

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", volumeValue);
        PlayerPrefs.SetFloat("VerticalSensitivity", VerticalSensitivity);
        PlayerPrefs.SetFloat("HorizontalSensitivity", HorizontalSensitivity);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        volumeValue = PlayerPrefs.GetFloat("Volume", 1f);
        VerticalSensitivity = PlayerPrefs.GetFloat("VerticalSensitivity", 110f);
        HorizontalSensitivity = PlayerPrefs.GetFloat("HorizontalSensitivity", 180f);

        int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        if (resolutionIndex < resolutionDropdown.options.Count)
        {
            resolutionDropdown.value = resolutionIndex;
            selectedResolution = availableResolutions[resolutionIndex];
        }
    }
    public void InitializeSettings(KayakController kayak)
    {
        kayakController = kayak;
        SetupResolutionDropdown();
        LoadSettings();
        AudioListener.volume = volumeValue;

        if (kayakController != null)
        {
            kayakController.mouseHorizontalSensitivity = HorizontalSensitivity;
            kayakController.mouseVerticalSensitivity = VerticalSensitivity;
        }

        // Si vous devez initialiser d'autres paramètres (par exemple, résolution)
        if (availableResolutions != null && resolutionDropdown != null)
        {
            int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
            if (resolutionIndex < availableResolutions.Length)
            {
                selectedResolution = availableResolutions[resolutionIndex];
                Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
            }
        }
    }
}
