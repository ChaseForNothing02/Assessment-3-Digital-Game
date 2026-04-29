using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ClassicMode");
    }
    public void StartCoinGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CoinChallengeMode");
    }
    public void StartThunderstormGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ThunderstormMode");
    }
    public void StartSpeedGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SpeedMode");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}