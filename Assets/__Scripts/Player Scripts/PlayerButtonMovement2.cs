using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonMovement2 : MonoBehaviour {
    bool isMoving = false;
    public GameObject playerMovement;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isMoving == true)
        {
            playerMovement.transform.position = new Vector2(playerMovement.transform.position.x + 1, 0);
        }
    }

    public void KeyDown() {
        isMoving = true;
    }

    public void KeyUp() {
        isMoving = false;
    }
}
