using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

// Very similar to the EnemySpawner script - this one is used only in the tutorial level of the game
public class TutorialEnemySpawner : MonoBehaviour {
    #region private variables
    [SerializeField]
    private Enemy enemy; // Reference to the enemy prefab
    private GameObject enemyParent; // Reference to the enemy parent object
    private int enemyCounter = 0; // Counter for enemies. It is incremented on enemy spawn
    private int maxEnemies = 5; // Determines maximum number of enemies that can be spawned

    private List<Enemy> enemies; // List of enemies
    #endregion

    // Start is called before the first frame update
    void Start() {
        enemies = new List<Enemy>(); // Instantiate new list of enemies

        /* 
         * Using the ParentUtils class, get the enemy parent object. An attempt to find the game object is made first.
         * If unable to be found, the game object is created 
         */
        enemyParent = ParentUtils.GetEnemyParent();
    }

    // Update is called once per frame
    void Update() {
        /* 
         * If the current value of enemyCounter is less than that of the value of maxEnemies, then a new enemy is spawned. The position of this new 
         * enemy is randomly determined using Random.Range. Random.Range takes in two values: an x and a y value. Since we don't want any enemies to 
         * spawn behind the player we enter 0 for the y value. The x value determines how closely grouped together the enemies will be when each of them 
         * are spawned. A bigger value will make it so that each enemy is spaced a good distance away from the next enemy
         */
        if (enemyCounter < maxEnemies) {
            enemy.transform.position = new Vector2(Random.Range(0, 1000f), 0);

            // Instantiate each enemy based on the positions calculated above
            Instantiate<Enemy>(enemy, enemyParent.transform);

            enemies.Add(enemy); // Add each enemy to the list
            enemyCounter++; // Increment the enemyCounter
        }
    }
}
