using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region private variables
    [SerializeField]
    private float moveSpeed = 5.0f;
    #endregion

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Get input from user
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        // Calculate new X position
        var newXPos = transform.position.x + deltaX;

        // Check vertical
        var deltaY = Input.GetAxis("Vertical");
        var newYPos = transform.position.y + deltaY;

        // Set current game object to the new position
        // transform.position = new Vector2(newXPos, newYPos);
        transform.position = new Vector2(newXPos, transform.position.y);
    }
}
