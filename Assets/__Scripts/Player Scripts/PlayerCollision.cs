using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    #region public variables
    //public PlayerMovement playerMovement; // Reference to player movement
    public static bool isBillyDead = false; // This is accessible from and can be checked whether or not the character is dead from other scripts
    public GameObject gameUI; // Creates a reference to the game's UI. In this case, the restart menu
    #endregion

    // Update is called once per frame
    void Update() {
        if (isBillyDead == true) {
            Debug.Log("You dead!");

            Application.Quit();
        } else {
            //Debug.Log("You ain't dead yet. Keep going!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D) {
        if (collision2D.gameObject.tag.Equals("Enemy")) {
            isBillyDead = true;
            Debug.Log("asad");
        }
    }

    void RestartGame() {
        /* Enables the game object. The game object in question is the pause menu UI. We set it to true here as we want to
         * enable it i.e. show it
         */
        gameUI.SetActive(true);
        Time.timeScale = 0f; // Freezes time in the game, effectively pausing the game

        isBillyDead = true;
    }
}
