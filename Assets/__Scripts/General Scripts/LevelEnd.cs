using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LevelEnd : MonoBehaviour {
    #region public variables
    //public GameObject gameUI; // Creates a reference to the game's UI. In this case, the level complete menu
    #endregion

    #region private variables
    private int collectiblesCollected;
    private int numberOfCollectibles;
    #endregion

    // Start is called before the first frame update
    void Start() {
        numberOfCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        Debug.Log(numberOfCollectibles);
    }

    void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.tag == "SceneChange") {
            Debug.Log("You have collected " + collectiblesCollected);

            // Saves the player's high score
            PlayerPrefs.SetInt("High Score", collectiblesCollected);
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
