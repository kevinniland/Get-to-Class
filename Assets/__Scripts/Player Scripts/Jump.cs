using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour {
    #region public variables
    public bool isGrounded;
    public float jumpVelocity = 1000f;
    public float jumpHeight;
    public float moveSpeed;
    #endregion

    #region private variables
    [SerializeField]
    private LayerMask groundLayerMask;

    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    #endregion

    // Start is called before the first frame update
    void Start() {
        rigidbody2D = transform.GetComponent<Rigidbody2D>(); // Get the rigid body component
        boxCollider2D = transform.GetComponent<BoxCollider2D>(); // Get the box collider component
    }

    // Check for collision. If the tag of the object is "Ground" and isGrounded is false i.e. the player is/was in the air, set isGrounded to false
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == ("Ground") && isGrounded == false) {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update() {
        // If the player is grounded and the player press the jump button, make the character jump
        if ((IsGrounded() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))) {
            rigidbody2D.velocity = Vector2.up * (jumpVelocity + jumpHeight);
        }

        // Handles jumping and moving at the same time
        JumpAndMove();
    }

    // Allows the player to control the character mid-jump
    private void JumpAndMove() {
        // If player presses right arrow, move the player right while in the air
        if (Input.GetKey(KeyCode.RightArrow)) {
            rigidbody2D.velocity = new Vector2(+moveSpeed, rigidbody2D.velocity.y);
        } else {
            // If player presses left arrow, move the player left in the air 
            if (Input.GetKey(KeyCode.LeftArrow)) {
                rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
            } else {
                // Else do nothing, essentially. Player will only jump up and down
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            }
        }
    }

    // Checks if the player is grounded
    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);

        return raycastHit2D.collider != null; 
    }
}
