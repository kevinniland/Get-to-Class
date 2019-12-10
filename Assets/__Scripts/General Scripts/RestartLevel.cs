using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour {
    #region public variables
    public static bool isBillyDead = false; // This is accessible from and can be checked whether or not the character is dead from other scripts
    public GameObject gameUI; // Creates a reference to the game's UI. In this case, the restart menu
    public PlayerMovement playerMovement;
    #endregion

    // Update is called once per frame
    void Update() {
        if (isBillyDead == true) {
            RestartGame();
        } else {
            Debug.Log("You ain't dead yet. Keep going!");
        }
    }

    public void RestartGame() {
        /* Enables the game object. The game object in question is the pause menu UI. We set it to true here as we want to
         * enable it i.e. show it
         */
        gameUI.SetActive(true);
        Time.timeScale = 0f; // Freezes time in the game, effectively pausing the game

        isBillyDead = true;
    }
}
