using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2Handler : MonoBehaviour
{
    public GameObject Level2PLaner;
    public Button NextLevel;
    public PlayerController player;
    public GameObject trees;
    public GameObject circle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Level2PLaner.SetActive(false);
        NextLevel.onClick.AddListener(Next);
        trees.SetActive(true);
        circle.SetActive(true);
    }

    public void Level2()
    {
        Level2PLaner.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Next()
    {
        Time.timeScale = 1f;
        Level2PLaner.SetActive(false);
        trees.SetActive(false);
        circle.SetActive(false);

    }
}
