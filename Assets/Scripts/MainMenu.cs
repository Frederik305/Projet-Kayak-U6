using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        // Remplacez "GameScene" par le nom de la sc�ne que vous voulez charger
        SceneManager.LoadScene("SceneKayak1");
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

    }
}
