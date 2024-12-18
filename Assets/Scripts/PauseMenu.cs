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
        gameSession.Finish();

    }
    public void OnSettingButtonClicked()
    {
        gameSession.Setting();
    }
   void OnResume()
    {
        gameSession.Resume();
    }
}
