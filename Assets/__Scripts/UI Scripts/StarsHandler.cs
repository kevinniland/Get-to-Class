using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHandler : MonoBehaviour {
    #region public variables
    public GameObject[] starsArray;
    #endregion

    #region private variables
    private int numberOfStars;
    #endregion

    // Start is called before the first frame update
    void Start() {
        numberOfStars = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    public void starsAchieved() {
        int collectiblesLeft = GameObject.FindGameObjectsWithTag("Collectible").Length;
        int collectiblesCollected = numberOfStars - collectiblesLeft;

        if (collectiblesCollected >= 2 && collectiblesCollected < 4) {
            starsArray[0].SetActive(true);
        } else if (collectiblesCollected >= 4 && collectiblesCollected < 6) {
            starsArray[0].SetActive(true);
            starsArray[1].SetActive(true);
        } else {
            starsArray[0].SetActive(true);
            starsArray[1].SetActive(true);
            starsArray[2].SetActive(true);
        }
    }
}
