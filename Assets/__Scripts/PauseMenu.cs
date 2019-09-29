using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    #region public variables
    public static bool isGamePaused = false; // This is accessible from and can be checked whether or not the game is paused from other scripts
    public GameObject gameUI; // Creates a reference to the game's UI. In this case, the pause menu
    public PlayerMovement playerMovement;
    #endregion

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (isGamePaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    // Can be called by resume game button press
    public void ResumeGame() {
        /* Disables the game object. The game object in question is the pause menu UI. We set it to false here as we want to
         * disable it i.e. prevent it from showing
         */ 
        gameUI.SetActive(false);
        Time.timeScale = 1f; // Sets the speed of the game back to normal

        isGamePaused = false; 
    }

    void PauseGame() {
        /* Enables the game object. The game object in question is the pause menu UI. We set it to true here as we want to
         * enable it i.e. show it
         */
        gameUI.SetActive(true); 
        Time.timeScale = 0f; // Freezes time in the game, effectively pausing the game

        isGamePaused = true;
    }

    public void QuitGame() {
        Application.Quit();

        Debug.Log("Quitting game...");
    }
}
