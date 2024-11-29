using UnityEngine;
using UnityEngine.InputSystem;

public class GameSession : MonoBehaviour
{
    private PlayerInput kayakInputs;
    private PauseMenu pauseMenu;
    [SerializeField] GameObject pauseMenuCanva;
    private Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("MiniMap");
        camera = gameObject.GetComponent<Camera>();
        camera.enabled = false;
        pauseMenu = GetComponent<PauseMenu>();
       pauseMenuCanva.SetActive(false);
    }
    
    public void Pause()
    {
        camera.Render();
        camera.Render();
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
