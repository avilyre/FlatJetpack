using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameControls;

    public static GameController instance;

    void Start()
    {
        instance = this;
        Time.timeScale = 1f;
        gameControls.SetActive(true);
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
        gameControls.SetActive(false);
        Time.timeScale = 0f; // 0 = Paused, 1 = Playing
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
