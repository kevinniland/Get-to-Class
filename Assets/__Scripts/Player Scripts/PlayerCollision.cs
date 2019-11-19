using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    #region public variables
    public PlayerMovement playerMovement; // Reference to player movement
    #endregion

    void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.tag == "Enemy") {
            Debug.Log("asad");
        }
    }
}
