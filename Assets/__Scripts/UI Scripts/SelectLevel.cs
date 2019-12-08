using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    #region public varibles
    public SceneFader sceneFader; // Reference to scene fader object
    #endregion

    // Start is called before the first frame update
    void Start() {
        // Keeps track of what levels are unlocked. We use PlayerPrefs as...
        int maxLevelReached = PlayerPrefs.GetInt("maxLevelReached", 1); 
    }

    // Transitions to the the specified level
    public void LevelSelect(string level) {
        sceneFader.FadeTransition(level);
    }
}
