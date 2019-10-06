using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {
    #region private variables
    [SerializeField]
    private string nextLevel;
    #endregion

    void OnTriggerEnter2D(Collider2D LoadSceneTrigger) {
        if (LoadSceneTrigger.CompareTag("Player")) {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
