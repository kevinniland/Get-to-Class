using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    #region public variables
    // Determines how fast the enemy will move once they detect and subsequently start following the player
    public float enemySpeed; 
    #endregion

    #region private variables
    // Reference to the game object the enemy will chase after. In this case, the player
    private Transform player; 
    #endregion

    // Start is called before the first frame update
    void Start() {
        // Finds the game object with the tag "Player" and also retrieves the transform information i.e. position of the player character
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        if (Vector2.Distance(transform.position, player.position) > 3) {
            // Moves the enemy from its current position to that of the player's position at a specified speed
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
        }
    }
}
