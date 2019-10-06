using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // In order to call this from the button, method needs to be public
    public void PlayGame() {
        // Loads next level in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quits the game
    public void QuitGame() {
        Application.Quit();
    }
}
