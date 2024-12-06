using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI elapsedTimeText;
    [SerializeField] protected TextMeshProUGUI traveledDistanceText;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetRiverDescentStat(float elapsedTime, float traveledDitance)
    {
        traveledDistanceText.text = "Distance traveled: "+ Mathf.Round(traveledDitance).ToString() + " meters";
        elapsedTimeText.text = "Time elapded: "+elapsedTime.ToString("F2") + " seconds";
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    } 
    public void QuitButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
