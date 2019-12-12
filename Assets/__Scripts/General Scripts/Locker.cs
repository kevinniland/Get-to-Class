using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour {
    #region public variables
    PlayerMovement player;
    BoxCollider2D boxCollider2D;
    public float disablePlatformEffectorFor = 0.5f; // Determines how long key must be held down before player can jump down from platform
    #endregion

    #region private variables
    private PlatformEffector2D platformEffector2D; // Reference to platform effector component on Locker sprite
    #endregion

    // Start is called before the first frame update
    void Start() {
        platformEffector2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update() {
        // If 'S' is pressed and value of disablePlatformEffectorFor is less than or equal to 0, flip the rotational offset of the platform effector
        if (Input.GetKeyDown(KeyCode.S)) {
            platformEffector2D.rotationalOffset = 180f;
        } 

        // To flip the rotational offset back to 0, we will check if the player has pressed the jump key. If they have, set the rotational offset back to 0
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            platformEffector2D.rotationalOffset = 0f;
        }
    }
}
