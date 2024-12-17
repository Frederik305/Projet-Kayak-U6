using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class GameSession : MonoBehaviour
{
    private PlayerInput kayakInputs;
    //private PauseMenu pauseMenu;
    [SerializeField] GameObject pauseMenuCanva;
    [SerializeField] GameObject settingsCanva;
    private Camera cameraMiniMap;
    private FinishLine finishLine;
    [SerializeField] GameObject gameOverCanva;
    private TracePlayerPath tracePlayerPath;
    private GameOver gameOver;
    private float elapsedTime = 0f;
    private SetOptions setting;
    [SerializeField] private AudioSource[] audioSourceList;
    private KayakController kayakController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject kayak = GameObject.Find("kayakparent(Clone)");
        kayakController = kayak.GetComponent<KayakController>();
        GameObject gameObject = GameObject.FindGameObjectWithTag("MiniMap");
        cameraMiniMap = gameObject.GetComponent<Camera>();
        cameraMiniMap.enabled = false;
        //pauseMenu = GetComponent<PauseMenu>();
       pauseMenuCanva.SetActive(false);
        tracePlayerPath = GetComponentInChildren<TracePlayerPath>();
        gameOver = gameOverCanva.GetComponent<GameOver>();
        gameOverCanva.SetActive(false);
        settingsCanva.SetActive(false);
        setting= settingsCanva.GetComponent<SetOptions>();
        setting.InitializeSettings(kayakController);

    }
    void Update()
    {
        // Si le jeu n'est pas mis en pause, on met à jour le temps écoulé
        if (Time.timeScale == 1)
        {
            elapsedTime += Time.deltaTime; // Accumule le temps écoulé depuis le dernier frame
        }

      
    }

    public void Pause()
    {
        cameraMiniMap.Render();
        StartCoroutine(RenderAfterInitialization());

        kayakInputs = FindFirstObjectByType<PlayerInput>();
        kayakInputs.SwitchCurrentActionMap("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuCanva.SetActive(true);
        Time.timeScale = 0;
        ToggleAudio();

    }
    public void Resume()
    {
        
        kayakInputs.SwitchCurrentActionMap("InGameControl");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuCanva.SetActive(false);
        Time.timeScale = 1;
        ToggleAudio();
    }
    public void Finish() {
        ToggleAudio();
        kayakInputs = FindFirstObjectByType<PlayerInput>();
        kayakInputs.SwitchCurrentActionMap("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverCanva.SetActive(true);
        Time.timeScale = 0;
        gameOver.SetRiverDescentStat(elapsedTime,tracePlayerPath.totalDistance);
        

    }
    public void Setting()
    {
        settingsCanva.SetActive(true);
        pauseMenuCanva.SetActive(false) ;

    }

    public void ToggleAudio()
    {
        foreach (AudioSource audioSource in audioSourceList)
        {
            if (audioSource.isPlaying)
            {
            audioSource.Pause();
            }
            else
            {
             audioSource.Play();
            }
        }
        
    }
    IEnumerator RenderAfterInitialization( )
    {
        // Attendre que tout soit prêt
        yield return new WaitForEndOfFrame();





        // Forcer le rendu
        cameraMiniMap.Render();
        
    }
}
