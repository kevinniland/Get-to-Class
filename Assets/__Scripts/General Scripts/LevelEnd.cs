using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LevelEnd : MonoBehaviour {
    #region public variables
    //public GameObject gameUI; // Creates a reference to the game's UI. In this case, the level complete menu
    #endregion

    #region private variables
    private int collectiblesCollected;
    private int enemiesDefeated;
    private int numberOfCollectibles;
    private int numberOfEnemies;
    #endregion

    // Start is called before the first frame update
    void Start() {
        numberOfCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Debug.Log(numberOfCollectibles);
        Debug.Log(numberOfEnemies);
    }

    void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.tag == "SceneChange") {
            Debug.Log("You have collected " + collectiblesCollected + " collectibles");
            Debug.Log("You have defeated " + enemiesDefeated + " enemies");

            // Saves the player's high score
            PlayerPrefs.SetInt("Collectibles", collectiblesCollected);
            PlayerPrefs.SetInt("Enemies", collectiblesCollected);
        } 

        if (collider2D.tag == "Collectible") {
            // Destroy/"Collect" the collectible
            Destroy(collider2D.gameObject);

            collectiblesCollected++;

            int totalCollectibles = collectiblesCollected;

            numberOfStars(totalCollectibles);
        }

        if (collider2D.tag == "Enemy") {
            enemiesDefeated++;

            int totalEnemies = enemiesDefeated;

            numOfEnemies(totalEnemies);
        }
    }

    public void numberOfStars(int collectiblesCollected) {
        Debug.Log(collectiblesCollected);
    }

    public void numOfEnemies(int enemiesDefeated) {
        Debug.Log(enemiesDefeated);
    }
}
