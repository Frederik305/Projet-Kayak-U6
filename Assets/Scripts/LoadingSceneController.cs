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
        // Lancez la coroutine pour charger la sc�ne principale en arri�re-plan
        StartCoroutine(LoadMainMenuAsync());
    }

    private IEnumerator LoadMainMenuAsync()
    {
        // Charge la sc�ne principale (par exemple le menu principal) en arri�re-plan
        AsyncOperation operation = SceneManager.LoadSceneAsync("Scene menu");

        // Emp�che la sc�ne de se charger imm�diatement
        operation.allowSceneActivation = false;

        // Boucle de mise � jour de la barre de progression pendant le chargement
        while (!operation.isDone)
        {
            // La progression de 0 � 0.9 indique le chargement de la sc�ne
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (loadingBar != null)
                loadingBar.value = progress;

            // Si le chargement est termin�, activez la sc�ne
            if (operation.progress >= 0.9f)
            {
                // Ajoutez un d�lai si vous souhaitez afficher un message "Chargement termin�"
                //loadingText.text = "Chargement termin� !";
                operation.allowSceneActivation = true;
            }

            yield return null;  // Attendre la prochaine frame
        }
    }

}
