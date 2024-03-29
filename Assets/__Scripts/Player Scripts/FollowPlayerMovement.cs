﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMovement : MonoBehaviour
{
    #region public variables
    public GameObject player; // Reference to the player
    #endregion

    #region private variables
    private Vector3 offset;
    #endregion
    
    void Start() {
        offset = transform.position - player.transform.position; // Calculates the offset (distance between camera and player)
    }

    void LateUpdate() {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
