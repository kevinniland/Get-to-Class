using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class EnemySpawner : MonoBehaviour {
    #region private variables
    [SerializeField]
    private Enemy enemyPrefab;
    private GameObject enemyParent;
    private float spawnDelay = 0.5f;
    private float spawnInterval = 0.5f;
    private int enemyCounter = 0;
    private int maxEnemies = 50;
    private bool enemiesSpawned = false;

    private List<Enemy> enemies;
    #endregion

    // Start is called before the first frame update
    void Start() {
        enemies = new List<Enemy>();
        enemyParent = ParentUtils.GetEnemyParent();

        // SpawnRepeating();
    }

    void Update() {
        if (enemyCounter < maxEnemies) {
            enemyPrefab.transform.position = new Vector2(Random.Range(0, 1000f), 0);

            Instantiate<Enemy>(enemyPrefab, enemyParent.transform);

            enemies.Add(enemyPrefab);
            enemyCounter++;
        } else {
            enemiesSpawned = true;
        }
    }

    //// invokeRepeating
    //private void SpawnRepeating() {
    //    InvokeRepeating("Spawn", spawnDelay, spawnInterval);
    //}

    //private void Spawn() {
    //    var randomIndex = Random.Range(0, spawnPoints.Count);
    //    var currPoint = spawnPoints[randomIndex];

    //    // var enemy = Instantiate(enemyPrefab); // Adds to the base level hierarchy
    //    var enemy = Instantiate(enemyPrefab, enemyParent.transform);
    //    enemy.transform.position = currPoint.transform.position;
    //}
}
