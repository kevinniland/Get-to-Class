using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour {
    public bool isGrounded;
    public float jumpVelocity = 1000f;
    public float jumpHeight;
    public float moveSpeed;

    [SerializeField]
    private LayerMask groundLayerMask;

    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    
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
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2D.velocity = Vector2.up * (jumpVelocity + jumpHeight);
        }

        JumpAndMove();
    }

    private void JumpAndMove() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            rigidbody2D.velocity = new Vector2(+moveSpeed, rigidbody2D.velocity.y);
        } else {
            if (Input.GetKey(KeyCode.LeftArrow)) {
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
