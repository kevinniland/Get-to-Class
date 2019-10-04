using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    #region private variables
    private Transform bar;
    #endregion

    // Start is called before the first frame update
    private void Start() {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(1f, 1f);
    }

    public void SetSize(float sizeNormalized) {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
