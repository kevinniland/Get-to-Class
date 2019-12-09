using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {
    #region public variables
    //public PlayerMovement playerMovement; // Reference to player movement
    public static bool isBillyDead = false; // This is accessible from and can be checked whether or not the character is dead from other scripts
    public GameObject gameUI; // Creates a reference to the game's UI. In this case, the restart menu
    public Image image; //  Reference to canvas image
    public Button button;
    public float time = 3;
    #endregion

    void OnCollisionEnter2D(Collision2D collision2D) {
        if (collision2D.gameObject.tag.Equals("Enemy")) {
            //Debug.Log("You died");

            //gameUI.SetActive(true);


            //StartCoroutine(DisplayGameOver());

            StartCoroutine(FadeIn());
        }
    }

    // Specifies the scene/level to fade/transition to
    public void FadeTransition(string level) {
        StartCoroutine(FadeOut(level));
    }

    IEnumerator DisplayGameOver() {
        Debug.Log("You died! Restarting level in 5 seconds...");
        //Time.timeScale = 0.1f;

        yield return new WaitForSeconds(1);

        StartCoroutine(FadeIn());

        Debug.Log("Restarting level now!");
    }

    // Fades the screen in when the game starts. Does this by using an 'image' placed over the canvas and slowly decreasing the alpha
    IEnumerator FadeIn() {
        float fadeTime = 1f;

        while (fadeTime > 0f) {
            fadeTime -= Time.deltaTime;
            image.color = new Color(0f, 0f, 0f, fadeTime);
            yield return 0; // Waits one frame and then continues
        }
    }

    // Fades the screen out. Does by increasing the alpha of the image placed over the main canvas
    IEnumerator FadeOut(string level) {
        float fadeTime = 0f;

        while (fadeTime < 1f) {
            fadeTime += Time.deltaTime;
            image.color = new Color(0f, 0f, 0f, fadeTime);
            yield return 0; // Waits one frame and then continues
        }

        // Pass in the scene to fade to 
        SceneManager.LoadScene("Level1");
    }
}
