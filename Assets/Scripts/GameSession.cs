using UnityEngine;
using UnityEngine.InputSystem;

public class GameSession : MonoBehaviour
{
    private PlayerInput kayakInputs;
    private PauseMenu pauseMenu;
    [SerializeField] GameObject pauseMenuCanva;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        pauseMenu = GetComponent<PauseMenu>();
       pauseMenuCanva.SetActive(false);
    }
    
    public void Pause()
    {
        kayakInputs = FindFirstObjectByType<PlayerInput>();
        kayakInputs.SwitchCurrentActionMap("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuCanva.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        
        kayakInputs.SwitchCurrentActionMap("InGameControl");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuCanva.SetActive(false);
        Time.timeScale = 1;
    }
}
