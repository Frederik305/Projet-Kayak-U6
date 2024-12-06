using UnityEngine;
using UnityEngine.InputSystem;

public class GameSession : MonoBehaviour
{
    private PlayerInput kayakInputs;
    //private PauseMenu pauseMenu;
    [SerializeField] GameObject pauseMenuCanva;
    private Camera camera;
    private FinishLine finishLine;
    [SerializeField] GameObject gameOverCanva;
    private TracePlayerPath tracePlayerPath;
    private GameOver gameOver;
    private float elapsedTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("MiniMap");
        camera = gameObject.GetComponent<Camera>();
        camera.enabled = false;
        //pauseMenu = GetComponent<PauseMenu>();
       pauseMenuCanva.SetActive(false);
        tracePlayerPath = GetComponentInChildren<TracePlayerPath>();
        gameOver = gameOverCanva.GetComponent<GameOver>();
        gameOverCanva.SetActive(false);

    }
    void Update()
    {
        // Si le jeu n'est pas mis en pause, on met � jour le temps �coul�
        if (Time.timeScale == 1)
        {
            elapsedTime += Time.deltaTime; // Accumule le temps �coul� depuis le dernier frame
        }

        // Affiche le temps �coul� dans la console (ou tu peux l'afficher � l'�cran)
        // Ici, on peut afficher le temps � la console, ou tu peux ajouter un texte UI si n�cessaire
        Debug.Log("Temps �coul�: " + elapsedTime.ToString("F2") + " secondes");
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
    public void Finish() {
        kayakInputs = FindFirstObjectByType<PlayerInput>();
        kayakInputs.SwitchCurrentActionMap("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverCanva.SetActive(true);
        Time.timeScale = 0;
        gameOver.SetRiverDescentStat(elapsedTime,tracePlayerPath.totalDistance);
        Debug.Log("test2");
    }
}
