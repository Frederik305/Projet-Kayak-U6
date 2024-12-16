using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settings;
    [SerializeField] private SetOptions setOptions;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private UnityEngine.UI.Slider loadingBar;
    public void Start()
    {
        setOptions.InitializeSettings();
        loadingScreen.SetActive(false); // Assurez-vous que l'écran de chargement est désactivé au départ
    }
    public void OnStartButtonClicked()
    {
        // Remplacez "GameScene" par le nom de la scène que vous voulez charger
        StartCoroutine(LoadSceneAsync("SceneKayak1"));
    }

    public void OnQuitButtonClicked()
    {
        // Ferme l'application
        Application.Quit();

        // Si vous testez dans l'éditeur Unity (pour voir le comportement avant de publier l'application), décommentez la ligne suivante pour quitter l'éditeur :
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void OnSettingButtonClicked()
    {
        settings.SetActive(true);
        mainMenu.SetActive(false);
    }
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        Debug.Log("Chargement de la scène commencé.");

        // Activez l'écran de chargement
        loadingScreen.SetActive(true);
        mainMenu.SetActive(false); // Cachez le menu principal pendant le chargement

        // Charge la scène en arrière-plan
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        if (operation == null)
        {
            Debug.LogError($"La scène {sceneName} n'a pas pu être trouvée ou chargée.");
            yield break;
        }

        operation.allowSceneActivation = false; // Empêche la scène de s'activer immédiatement

        // Met à jour la barre de progression pendant le chargement
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Normalise la progression entre 0 et 1
            Debug.Log($"Progression : {progress * 100}%");

            if (loadingBar != null)
                loadingBar.value = progress;

            // Une fois que le chargement est terminé, activez la scène
            if (operation.progress >= 0.9f)
            {
                Debug.Log("Chargement terminé. Activation de la scène.");
                operation.allowSceneActivation = true;
            }

            yield return null; // Attend la prochaine frame
        }

        Debug.Log("La scène a été activée avec succès.");
    }

}
