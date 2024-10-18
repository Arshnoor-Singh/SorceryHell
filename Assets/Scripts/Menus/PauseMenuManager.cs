using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager Instance;
   
    private bool isGamePaused = false;
    public GameObject pauseMenuCanvas;
    public Button resumeButton;
    public Button quitButton;
    
    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }

        // Disable canvas at game start
        pauseMenuCanvas.SetActive(false);

        resumeButton.onClick.AddListener(() => ResumeButtonPressed());

        quitButton.onClick.AddListener(() => QuitButtonPressed());
    }

    public void ResumeButtonPressed()
    {
        // Unpause the game
        isGamePaused = false;
        Time.timeScale = 1;

        // Disavble canvas when game resumes
        pauseMenuCanvas.SetActive(false);
    }

    public void QuitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");

        // Unpause the game
        isGamePaused = false;
        Time.timeScale = 1;
        // disable canvas when the going back to main menu
        pauseMenuCanvas.SetActive(false);

    }

    public void ToggleGamePause()
    {
        if(isGamePaused == false) // Game is running and not pause
        {
            //Pause the game
            isGamePaused = true;
            Time.timeScale = 0;

            // Enable canvas when pausing
            pauseMenuCanvas.SetActive(true);
        }
        else
        {   
            // Unpause the game
            isGamePaused = false;
            Time.timeScale = 1;

            // Disable canvas when resuming
            pauseMenuCanvas.SetActive(false);
        }
    }

}
