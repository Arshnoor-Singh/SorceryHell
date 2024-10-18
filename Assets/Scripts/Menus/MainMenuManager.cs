using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private void Awake()
    {
        startButton.onClick.AddListener(() => OnStartButtonPressed());

        quitButton.onClick.AddListener(() => OnQuitButtonPressed());
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Level01");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
