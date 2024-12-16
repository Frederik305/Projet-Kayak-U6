using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour
{
    [SerializeField] private Slider loadingBar;  // Barre de progression
    //[SerializeField] private Text loadingText;   // Texte de chargement (facultatif)

    void Start()
    {
        // Lancez la coroutine pour charger la scène principale en arrière-plan
        StartCoroutine(LoadMainMenuAsync());
    }

    private IEnumerator LoadMainMenuAsync()
    {
        // Charge la scène principale (par exemple le menu principal) en arrière-plan
        AsyncOperation operation = SceneManager.LoadSceneAsync("Scene menu");

        // Empêche la scène de se charger immédiatement
        operation.allowSceneActivation = false;

        // Boucle de mise à jour de la barre de progression pendant le chargement
        while (!operation.isDone)
        {
            // La progression de 0 à 0.9 indique le chargement de la scène
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (loadingBar != null)
                loadingBar.value = progress;

            // Si le chargement est terminé, activez la scène
            if (operation.progress >= 0.9f)
            {
                // Ajoutez un délai si vous souhaitez afficher un message "Chargement terminé"
                //loadingText.text = "Chargement terminé !";
                operation.allowSceneActivation = true;
            }

            yield return null;  // Attendre la prochaine frame
        }
    }

}
