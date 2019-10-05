using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour {
    #region public variables
    public GameObject[] levels; // List of game objects - contains the background objects to be repeated
    public float choke; // 
    #endregion

    #region private variables
    private Camera camera; // Reference to main camera
    private Vector2 screenBounds; // Stores the boundaries of this camera
    #endregion
    
    void Start() {
        camera = gameObject.GetComponent<Camera>(); // Define the main camera - the game object that is holding the script

        /* Retrieves the dimensions of the camera in world space
         * ========================================================
         * Takes the screen width & height and then plots it on an x and y axis
         */ 
        screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z)); // Retrieves the dimensions of the camera in world space

        /* Iterates through the game objects contained in the list
         * ========================================================
         * 'gameObject' creates a local reference which contains the value of the current row in the list.
         * Doing this, we can call the function 'LoadChildObjects' and pass 'gameObject' in as a reference - this goes through 
         * the entire list of sprites and repeat the last one first, then the second last one and so on. In Unity, we define the size of the list and define each element afterwards
         */
        foreach (GameObject gameObject in levels) {
            LoadChildObjects(gameObject);
        }
    }

    // Loads the background 'sprites' so that they fill the screen
    void LoadChildObjects(GameObject gameObject) {
        // Gives horizontal value of the boundary box of the sprite
        float objectWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x - choke;

        // Determines number of clones needed to fill the width of the screen. Need to cast to int as screenBounds and objectWidth are floats
        int childsNeeded = (int) Mathf.Ceil((screenBounds.x * 2) / objectWidth);

        // Clone the sprites
        GameObject clone = Instantiate(gameObject) as GameObject;

        // Creates all child objects
        for (int i = 0; i <= childsNeeded; i++) {
            GameObject gOC = Instantiate(clone) as GameObject;

            // Sets new clone to be a child object of the player object, and sets their position
            gOC.transform.SetParent(gameObject.transform);
            gOC.transform.position = new Vector3(objectWidth * i, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        // Destroy clone object and sprite renderer object of parent object
        Destroy(clone);
        Destroy(gameObject.GetComponent<SpriteRenderer>());
    }

    // Reposition child objects so they are always filling the scene
    void repositionChildObjects(GameObject gameObject) {
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();

        if (children.Length > 1) {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;

            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;

            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth) {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, 
                    lastChild.transform.position.y, lastChild.transform.position.z);
            } else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth) {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, 
                    firstChild.transform.position.z);
            }
        }
    }
    
    void LateUpdate() {
        foreach(GameObject gameObject in levels) {
            repositionChildObjects(gameObject);
        }
    }
}
