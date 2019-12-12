using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enables or disables certain buttons in the game if the build is Android
public class AndroidBuild : MonoBehaviour {
    #region public variables
    public GameObject gameUI; // Reference to gameUI
    #endregion

    // Start is called before the first frame update
    void Start() {
        if (Application.platform == RuntimePlatform.Android) {
            Debug.Log("You are playing on Android");

            gameUI.SetActive(true);
        } else {
            Debug.Log("You are playing on PC");

            gameUI.SetActive(false);
        }
    }
}
