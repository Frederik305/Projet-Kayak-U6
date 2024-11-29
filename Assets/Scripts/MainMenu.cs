using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        // Remplacez "GameScene" par le nom de la scène que vous voulez charger
        SceneManager.LoadScene("SceneKayak1");
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

    }
}
