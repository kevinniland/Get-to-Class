using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButtonMovement : MonoBehaviour {
    #region public variables
    public PlayerMovement playerMovement;
    #endregion

    #region private variables
    [SerializeField]
    private float moveSpeed = 5.0f;
    private bool moveLeft;
    private bool isMoving; 
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private Button moveLeftButton { get { return GetComponent<Button>(); } }
    private Button moveRightButton { get { return GetComponent<Button>(); } }
    #endregion

    // Start is called before the first frame update
    void Start() {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        if (Input.GetButtonDown("RightButton")) {
            rigidbody2D.velocity = new Vector2(+moveSpeed, rigidbody2D.velocity.y);
        } else if (Input.GetButton("LeftButton")) {
            rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
        }
    }
}
