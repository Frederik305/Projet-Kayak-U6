using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameSession gameSession;
    void Start()
    {
        gameSession = gameObject.GetComponentInParent<GameSession>();
    }
    public void OnResumeButtonClicked()
    {
        gameSession.Resume();
    }

    public void OnQuitButtonClicked()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Scene menu");
        
    }
    public void OnSettingButtonClicked()
    {

    }
}
