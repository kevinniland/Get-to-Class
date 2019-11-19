using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    #region public varibles
    public SceneFader sceneFader; // Reference to scene fader object
    public Button[] buttonLevelArray; // Will contain references to all the buttons used to select a level
    #endregion

    // Start is called before the first frame update
    void Start() {
        // Keeps track of what levels are unlocked. We use PlayerPrefs as...
        int maxLevelReached = PlayerPrefs.GetInt("maxLevelReached", 1); 

        // When we first load up the scene, specifically the main menu, we loop through all of our level select buttons
        for (int i = 0; i < buttonLevelArray.Length; i++) {
            if (i + 1 > maxLevelReached) {
                // For the button at index i, prevent that button from being interactable
                buttonLevelArray[i].interactable = false;
            }
        }
    }

    // Transitions to the the specified level
    public void LevelSelect(string level) {
        sceneFader.FadeTransition(level);
    }
}
