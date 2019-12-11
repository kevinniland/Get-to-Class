using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    #region public variables
    public Text collectiblesText;
    public Text enemiesText;
    #endregion

    void Start() {
        collectiblesText.text = PlayerPrefs.GetInt("Collectibles").ToString();
        enemiesText.text = PlayerPrefs.GetInt("Enemies").ToString();
    }
}
