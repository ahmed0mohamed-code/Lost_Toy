using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerHandler : MonoBehaviour
{
    public GameObject WinnerPanel;
    public Button Restartbutton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinnerPanel.SetActive(false);
        Restartbutton.onClick.AddListener(RestartGame);
    }

    public void showWinnerScreen()
    {
        WinnerPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
