using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class EnemySpawner : MonoBehaviour {
    #region private variables
    [SerializeField]
    private Enemy enemyPrefab;
    private float spawnDelay = 0.5f;
    private float spawnInterval = 0.5f;

    private IList<SpawnPoint> spawnPoints;

    private GameObject enemyParent;
    #endregion

    // Start is called before the first frame update
    void Start() {
        enemyParent = ParentUtils.GetEnemyParent();

        // Need to get a list of spawn points
        spawnPoints = GetComponentsInChildren<SpawnPoint>();

        SpawnRepeating();
    }

    // invokeRepeating
    private void SpawnRepeating() {
        InvokeRepeating("Spawn", spawnDelay, spawnInterval);
    }

    private void Spawn() {
        var randomIndex = Random.Range(0, spawnPoints.Count);
        var currPoint = spawnPoints[randomIndex];

        // var enemy = Instantiate(enemyPrefab); // Adds to the base level hierarchy
        var enemy = Instantiate(enemyPrefab, enemyParent.transform);
        enemy.transform.position = currPoint.transform.position;
    }
}
