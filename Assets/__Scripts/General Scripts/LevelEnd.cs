using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {
    #region public variables
    public GameObject gameUI; // Creates a reference to the game's UI. In this case, the pause menu
    public int collectiblesCollected;
    #endregion

    void LevelComplete() {
        /* Enables the game object. The game object in question is the pause menu UI. We set it to true here as we want to
         * enable it i.e. show it
         */
        gameUI.SetActive(true);
        Time.timeScale = 0f; // Freezes time in the game, effectively pausing the game
    }

    void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.tag == "SceneChange") {
            Debug.Log("You have collected " + collectiblesCollected);

            LevelComplete();
        } else {
            Debug.Log("Keep going!");
        }

        if (collider2D.tag == "Collectible") {
            // Destroy/"Collect" the collectible
            Destroy(collider2D.gameObject);

            collectiblesCollected++;

            int totalCollectibles = collectiblesCollected;

            numberOfStars(totalCollectibles);
        }
    }

    public void numberOfStars(int collectiblesCollected) {
        Debug.Log(collectiblesCollected);
    }
}
