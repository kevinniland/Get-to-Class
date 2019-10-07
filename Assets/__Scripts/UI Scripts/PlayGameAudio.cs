using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayGameAudio : MonoBehaviour {
    #region public variables
    public AudioClip schoolBell; // Reference to audio clip
    #endregion

    #region private variables
    // Reference to button that will play the sound. Returns button component on game object
    private Button playGameButton { get { return GetComponent<Button>(); } }

    // Reference to audio source. Returns audio source component on game object
    private AudioSource schoolBellSource { get { return GetComponent<AudioSource>(); } }
    #endregion

    // Start is called before the first frame update
    void Start() {
        // Adds audio source component to the game object
        gameObject.AddComponent<AudioSource>();

        schoolBellSource.clip = schoolBell; // Sets the school bell's audio source to the school bell audio clip
        schoolBellSource.playOnAwake = false; // Prevents sound from playing on awake

        // Calls the PlaySound function when the button is pressed
        playGameButton.onClick.AddListener(()=>PlaySound());
    }

    // Plays the audio clip
    void PlaySound() {
        // Plays the clip once, and scales the volume by volumeScale
        schoolBellSource.PlayOneShot(schoolBell);
    }
}
