using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // This is value that will be used to check if the game is paused or not
    public static bool gameIsPaused = false;
    // This is the game object that will be used to pause the game
    public GameObject pauseMenuUI;

    // Resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    // Pause the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    // Quit the game
    public void Quit()
    {
        Application.Quit();
    }

}
