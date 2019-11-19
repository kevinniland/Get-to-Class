using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInstructions : MonoBehaviour {
    #region public variables
    public static bool isGamePaused = false; // This is accessible from and can be checked whether or not the game is paused from other scripts
    public GameObject gameUI1; // Creates a reference to the game's UI. In this case, the pause menu
    public GameObject gameUI2;
    public PlayerMovement playerMovement;
    #endregion

    // Update is called once per frame
    void Update() {
        
    }

    public void PopupDisabled() {
        /* Disables the game object. The game object in question is the pop up. We set it to false here as we want to
         * disable it i.e. prevent it from showing
         */
        gameUI1.SetActive(false);
        gameUI2.SetActive(false);
        Time.timeScale = 1f; // Sets the speed of the game back to normal

        isGamePaused = false;
    }

    void PopupEnabled() {
        /* Enables the game object. The game object in question is the pop up. We set it to true here as we want to
         * enable it i.e. show it
         */
        gameUI1.SetActive(true);
        gameUI2.SetActive(true);
        Time.timeScale = 0f; // Freezes time in the game, effectively pausing the game

        isGamePaused = true;
    }
}
