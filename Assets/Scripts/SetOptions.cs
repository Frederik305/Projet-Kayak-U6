using UnityEngine;

public class SetOptions : MonoBehaviour
{
    [SerializeField] private GameObject kayak;
    
    public void SetGlobalSoundVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ToggleMute(bool mute)
    {
        AudioListener.volume = mute ? 0f : 1f;
    }

    public void SetMouseVerticalSensitivity(float verticalSensitivity) 
    {
        KayakController kayakController = kayak.GetComponent<KayakController>();
        kayakController.mouseVerticalSensitivity = verticalSensitivity;
    }

    public void SetMouseHorizontalSensitivity(float horizontalSensitivity)
    {
        KayakController kayakController = kayak.GetComponent<KayakController>();
        kayakController.mouseHorizontalSensitivity = horizontalSensitivity;
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
}
