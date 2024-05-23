using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool isPaused = false;
    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isPaused)
            {
                isPaused = true;
                pauseScreen.SetActive(true);
            } else if (isPaused)
            {
                isPaused = false;
                pauseScreen.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
