using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    #region public variables
    public string loadLevel = "Level1";
    public SceneFader sceneFader; // Reference to scene fader object
    #endregion

    // In order to call this from the button, method needs to be public
    public void PlayGame() {
        //switch (this.gameObject.name)
        //{
        //    case "Level1Button":
        //        SceneManager.LoadScene("Level1");
        //        Debug.Log("Button pressed");
        //        break;
        //    case "Level2Button":
        //        SceneManager.LoadScene("Level2");
        //        break;
        //    case "Level3Button":
        //        SceneManager.LoadScene("Level3");
        //        break;
        //}

        sceneFader.FadeTransition(loadLevel);
    }

    // Quits the game
    public void QuitGame() {
        Application.Quit();
    }
}
