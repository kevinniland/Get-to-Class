using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {
    #region
    public Image image; //  Reference to canvas image
    #endregion

    void Start() {
        // 
        StartCoroutine(FadeIn());
    }

    // Specifies the scene/level to fade/transition to
    public void FadeTransition(string level) {
        StartCoroutine(FadeOut(level));
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
        SceneManager.LoadScene(level);
    }
}
