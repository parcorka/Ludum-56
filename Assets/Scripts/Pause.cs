using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseGameUI;

    private void Start()
    {
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                PauseGame();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseGameUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    private void PauseGame()
    {
        pauseGameUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused=true;
    }
    public void Options()
    {

    }
    public void QuitGame()
    {
        Debug.Log("Quiting the game");
        Application.Quit();
    }
}
