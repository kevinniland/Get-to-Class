using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour {
    #region public variables
    public AudioMixer audioMixer;  // Reference to audio mixer
    public Slider musicSlider; // Reference to music slider
    #endregion

    void Start() {
        musicSlider.value = PlayerPrefs.GetFloat("MusicSlider", 0.75f);
    }

    /*
     * Due to a bug in Unity, we need to retrieve the value of the slider ourselves. Normally, we would pass in a value to this function and then
     * using the OnValueChanged() feature on the slider, reference the MusicSlider script and use the dynamic float variation of SetMusicVolume() function
     * from the list
     */
    // public void SetMusicVolume(float sliderVolume) {  
    public void SetMusicVolume() {
        float volumeVlaue = musicSlider.value;
        /* 
         * Takes in two parameters - name of the exposed parameter and the value on the slider i.e the volume
         * Need to convert sliderVolume to a logarithmic value. We also set the minimum value on the slider to be 0.0001. Having the minimum value 
         * be 0 will break this whole feature if the music volume ever does become 0
         */
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volumeVlaue) * 20);
        PlayerPrefs.GetFloat("MusicSlider", volumeVlaue);
    }
}
