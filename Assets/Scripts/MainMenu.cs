using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play Game button
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit button
    public void QuitGame ()
    {
        Application.Quit();
    }

    // Fullscreen toggle
    public void FullscreenToggle (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
