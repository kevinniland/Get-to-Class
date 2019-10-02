using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// No need for MonoBehaviour in this script as this is not going to act as a component in the game
[System.Serializable] // Allows you to save player data to a file
public class PlayerSaveData {
    #region public variables
    /* 
     * The player's position is defined as a Vector3. However, you are unable to serialize Unity specific. A float array can be used in this case
     * and will store the player's position at time of save
     */ 
    public float[] playerPosition;
    #endregion

    // Takes in data from PlayerMovement script
    public PlayerSaveData(PlayerMovement playerMovement) {
        playerPosition = new float[3]; // Create new float array with three elements - one for the x, y, and z 
        playerPosition[0] = playerMovement.transform.position.x;
        playerPosition[1] = playerMovement.transform.position.y;
        playerPosition[2] = playerMovement.transform.position.z;
    }
}
