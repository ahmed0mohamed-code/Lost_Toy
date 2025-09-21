using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    public GameObject gameoverpanel;
    public Button restartButton;
    public Level2Handler circlehandler;
    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameoverpanel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void ShowGameOver()
    {
        gameoverpanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        
        if (circlehandler.circle.activeInHierarchy)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            playerController.transform.position = new Vector2(-19.4f, -3.19f);
            Time.timeScale = 1f;                   
            gameoverpanel.SetActive(false);
            playerController.changehealth(5);
        }
    }
}
