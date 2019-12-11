using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {
    #region public variables
    public static bool isBillyDead = false; // This is accessible from and can be checked whether or not the character is dead from other scripts
    public Image image; //  Reference to canvas image
    FollowPlayer[] enemies; // Array for all enemies - used to freeze enemies on collision
    PlayerMovement player; // Reference to player - used primarily to freeze the player on collision
    public GameObject gameUI; // Reference to game over menu
    #endregion

    /*
     * On collision, check if the object the player collided with has the tag "Enemy", find the object of type "PlayerMovement", then calls PlayerDied()
     * This will disable player movement temporarily until the level restarts. Then start a coroutine for the game over sequence
     */
    void OnCollisionEnter2D(Collision2D collision2D) {
        if (collision2D.gameObject.tag.Equals("Enemy")) {
            player = FindObjectOfType<PlayerMovement>(); // Find the object of type PlayerMovement
            player.PlayerDied(); // Disables player movement

            gameUI.SetActive(true); // Set the game over UI menu to active on collision

            StartCoroutine(DisplayGameOver()); // Start the game over sequence
        }
    }

    // Specifies the scene/level to fade/transition to
    public void FadeTransition(string level) {
        StartCoroutine(FadeOut(level)); // Fade out of the level
    }

    // Game over sequence
    IEnumerator DisplayGameOver() {
        Debug.Log("You died! Restarting level...");
        enemies = FindObjectsOfType<FollowPlayer>(); // Find all objects of type FollowPlayer

        // For every enemy in the enemies array, freeze each enemy (similar to what we did with the player)
        for(int i = 0; i <= enemies.Length - 1; i++) {
            enemies[i].FreezeEnemies();
        }
        
        yield return new WaitForSeconds(1); // Wait one second

        StartCoroutine(FadeIn()); // Fade into the level

        // Get the active scene - used to restart a specific level
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);

        // Restarts the level
        switch (scene.name) {
            case "Level1":
                SceneManager.LoadScene("Level1");
                break;
            case "Level2":
                SceneManager.LoadScene("Level2");
                break;
            case "Level3":
                SceneManager.LoadScene("Level3");
                break;
        }

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
        SceneManager.LoadScene(level);
    }
}
