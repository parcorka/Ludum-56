using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseGameUI;
    public CameraController cameraController;

    private void Start()
    {
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!gameIsPaused)
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
        cameraController.mouse_sens = 10f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    private void PauseGame()
    {
        pauseGameUI.SetActive(true);
        cameraController.mouse_sens = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        gameIsPaused=true;
    }
    //public void Options()
    //{

    //}
    public void QuitGame()
    {
        Debug.Log("Quiting the game");
        Application.Quit();
    }
}
