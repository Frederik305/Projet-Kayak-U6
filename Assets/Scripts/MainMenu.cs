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
        loadingScreen.SetActive(false); // Assurez-vous que l'�cran de chargement est d�sactiv� au d�part
    }
    public void OnStartButtonClicked()
    {
        // Remplacez "GameScene" par le nom de la sc�ne que vous voulez charger
        StartCoroutine(LoadSceneAsync("SceneKayak1"));
    }

    public void OnQuitButtonClicked()
    {
        // Ferme l'application
        Application.Quit();

        // Si vous testez dans l'�diteur Unity (pour voir le comportement avant de publier l'application), d�commentez la ligne suivante pour quitter l'�diteur :
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
        Debug.Log("Chargement de la sc�ne commenc�.");

        // Activez l'�cran de chargement
        loadingScreen.SetActive(true);
        mainMenu.SetActive(false); // Cachez le menu principal pendant le chargement

        // Charge la sc�ne en arri�re-plan
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        if (operation == null)
        {
            Debug.LogError($"La sc�ne {sceneName} n'a pas pu �tre trouv�e ou charg�e.");
            yield break;
        }

        operation.allowSceneActivation = false; // Emp�che la sc�ne de s'activer imm�diatement

        // Met � jour la barre de progression pendant le chargement
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Normalise la progression entre 0 et 1
            Debug.Log($"Progression : {progress * 100}%");

            if (loadingBar != null)
                loadingBar.value = progress;

            // Une fois que le chargement est termin�, activez la sc�ne
            if (operation.progress >= 0.9f)
            {
                Debug.Log("Chargement termin�. Activation de la sc�ne.");
                operation.allowSceneActivation = true;
            }

            yield return null; // Attend la prochaine frame
        }

        Debug.Log("La sc�ne a �t� activ�e avec succ�s.");
    }

}
