using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonMovement1 : MonoBehaviour {
    #region public variables
    public GameObject playerMovement;
    public bool isGrounded;
    public float jumpVelocity = 1000f;
    public float jumpHeight;
    public float moveSpeed;
    #endregion

    #region private variables
    private bool isMoving = false;
    [SerializeField]
    private LayerMask groundLayerMask;

    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    #endregion

    // Start is called before the first frame update
    void Start() {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == ("Ground") && isGrounded == false) {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (isMoving == true) {
            playerMovement.transform.position = new Vector2(playerMovement.transform.position.x - moveSpeed, 0);
        }

        if ((IsGrounded() && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))) {
            rigidbody2D.velocity = Vector2.up * (jumpVelocity + jumpHeight);
        }

        JumpAndMove();
    }

    public void KeyDown() {
        isMoving = true;
    }

    public void KeyUp() {
        isMoving = false;
    }

    private void JumpAndMove() {
        if (isMoving == true) {
            rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
        } else {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);

        return raycastHit2D.collider != null;
    }
}
