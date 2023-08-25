using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;

    public static GameController instance;

    void Start()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; // 0 = Paused, 1 = Playing
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
