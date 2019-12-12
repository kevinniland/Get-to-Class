using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    #region public variables
    public PlayerMovement playerMovement;
    public SceneFader sceneFader; // Reference to scene fader object
    public LayerMask accessibleLayers; // Determines what layers the player can jump/move on
    public bool isMoving = true;
    #endregion

    #region private variables
    // Serialize this field - allows us to change the values of this in the Unity editor itself
    [SerializeField]
    private float moveSpeed = 5.0f;
    #endregion

    // Update is called once per frame
    void Update() {
        // Call Move() every frame if player is still alive
        if (isMoving) {
            Move();
        }
    }

    private void Move() {
        // Get input from user
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        // Calculate new X position
        var newXPos = transform.position.x + deltaX;

        // Set current game object to the new position
        transform.position = new Vector2(newXPos, transform.position.y);
    }

    public void SaveGameState() {
        // Call SavePlayerData from the SaveGame script and pass in this i.e. the player
        SaveGame.SavePlayerData(this);
    }

    // Loads the game state - very basic load game implementation. Loads the players previously saved position
    public void LoadGameState() {
        PlayerSaveData playerSaveData = SaveGame.LoadPlayerData();

        // Vector3 to store player position on the x, y, and z axis
        Vector3 savedPlayerPosition;
        savedPlayerPosition.x = playerSaveData.playerPosition[0];
        savedPlayerPosition.y = playerSaveData.playerPosition[1];
        savedPlayerPosition.z = playerSaveData.playerPosition[2];

        // Current position of the player is then set to that of the saved position
        transform.position = savedPlayerPosition;
    }

    public void PlayerDied() {
        isMoving = false;
    }
}
