using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    #region private variables
    private Rigidbody2D rigidbody2D;
    #endregion

    void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.tag == "Player") {
            Destroy(this.gameObject);
        }
    }
}
