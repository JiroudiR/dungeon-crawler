using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles quitting out of the game
/// </summary>
public class QuitGameButton : MonoBehaviour
{
    /// <summary>
    /// Description:
    /// Closes the game or exits play mode depending on the case
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
