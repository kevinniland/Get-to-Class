using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class LockerSpawner : MonoBehaviour {
    #region private variables
    [SerializeField]
    private Locker lockerPrefab; // Reference to the singular locker prefab
    private GameObject lockerParent; // Reference to the locker parent object
    private int lockerCounter = 0; // Counter for lockers. It is incremented on locker spawn
    private int maxLockers = 100; // Determines maximum number of locker that can be spawned

    private List<Locker> lockers; // List of enemies
    #endregion

    // Start is called before the first frame update
    void Start() {
        lockers = new List<Locker>();

        /* 
         * Using the ParentUtils class, get the locker parent object. An attempt to find the game object is made first.
         * If unable to be found, the game object is created 
         */
        lockerParent = ParentUtils.GetLockerParent();
    }

    // Update is called once per frame
    void Update() {
        if (lockerCounter < maxLockers) {
            lockerPrefab.transform.position = new Vector2(Random.Range(0, 1000f), 0);

            // Instantiate each enemy based on the positions calculated above
            Instantiate<Locker>(lockerPrefab, lockerParent.transform);

            lockers.Add(lockerPrefab); // Add each enemy to the list
            lockerCounter++; // Increment the enemyCounter
        }
    }
}
