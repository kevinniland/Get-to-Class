using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {
    #region public variables
    public SceneFader sceneFader;

    public string levelToUnlockName = "Level2";
    public int levelToUnlockIndex = 2;
    #endregion

    #region private variables
    [SerializeField]
    private string nextLevel;
    #endregion

    void OnTriggerEnter2D(Collider2D LoadSceneTrigger) {
        //if (LoadSceneTrigger.CompareTag("Player")) {
        //    SceneManager.LoadScene(nextLevel);
        //}
    }

    public void LevelProgression() {
        Debug.Log("Level completed");

        sceneFader.FadeTransition(levelToUnlockName);
    }
}
