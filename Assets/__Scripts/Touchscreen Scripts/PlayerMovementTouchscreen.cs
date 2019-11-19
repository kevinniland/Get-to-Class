using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for player movement on a mobile device
public class PlayerMovementTouchscreen : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        //// Check for number of touches on screen
        //if (Input.touchCount > 0) {
        //    Touch touch = Input.GetTouch(0); // Gets the index of the touch - in this case, we're getting the first touch

        //    /*
        //     * touch.position gets screen coordinates in pixels (screen space) but the position of the object is measured in units (world space),
        //     * therefore we must convert from screen space to world space
        //     */
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

        //    touchPosition.z = 0f; // We don't want the z value to be affected so just set it to 0
        //    transform.position = touchPosition;
        //}

        for (int i = 0; i < Input.touchCount; i++) {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
        }
    }
}
