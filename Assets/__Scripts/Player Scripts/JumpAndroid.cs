using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpAndroid : MonoBehaviour {
    #region public variables
    public Button buttonOne;
    public Button buttonTwo;
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
        if ((IsGrounded() && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
            rigidbody2D.velocity = Vector2.up * (jumpVelocity + jumpHeight);
        }

        JumpAndMove();
    }

    // Allows the player to control the character mid-jump
    private void JumpAndMove() { 
        if (buttonOne.name == "RightButton") {
            rigidbody2D.velocity = new Vector2(+moveSpeed, rigidbody2D.velocity.y);
        } else {
            if (buttonTwo.name == "LeftButton") {
                rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
            } else {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            }
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);

        return raycastHit2D.collider != null;
    }
}
