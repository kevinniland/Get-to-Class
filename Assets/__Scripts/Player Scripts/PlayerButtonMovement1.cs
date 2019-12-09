using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButtonMovement1 : MonoBehaviour {
    #region public variables
    public GameObject playerMovement;
    public float moveSpeed;
    public Button button;
    #endregion

    #region private variables
    private bool isMoving = false;
    #endregion

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isMoving == true) {
            if (button.name == "LeftButton") {
                Debug.Log("Moving left");
                playerMovement.transform.position = new Vector2(playerMovement.transform.position.x - moveSpeed, playerMovement.transform.position.y);
            }

            if (button.name == "RightButton") {
                Debug.Log("Moving left");
                playerMovement.transform.position = new Vector2(playerMovement.transform.position.x + moveSpeed, playerMovement.transform.position.y);
            }
        }
    }

    public void KeyDown() {
        isMoving = true;
    }

    public void KeyUp() {
        isMoving = false;
    }
}
