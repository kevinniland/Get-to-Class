using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region private variables
    private Rigidbody2D rigidbody2D;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.tag == "Player") {
            Destroy(this.gameObject);
        }
    }
}
