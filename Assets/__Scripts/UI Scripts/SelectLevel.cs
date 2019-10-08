using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour {
    #region public varibles
    public SceneFader sceneFader; // Reference to scene fader object
    #endregion

    public void LevelSelect (string level) {
        sceneFader.FadeTransition(level);
    }
}
