using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    #region public variables
    public Text highScoreText;
    #endregion

    void Start() {
        //highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score");
    }
}
