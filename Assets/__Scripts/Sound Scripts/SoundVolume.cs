using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundVolume : MonoBehaviour {
    #region public variables
    public AudioMixer audioMixer;  // Reference to audio mixer
    public Slider soundSlider; // Reference to sound slider
    #endregion

    void Start() {
        soundSlider.value = PlayerPrefs.GetFloat("SoundSlider", 0.75f);
    }

    /*
     * Due to a bug in Unity, we need to retrieve the value of the slider ourselves. Normally, we would pass in a value to this function and then
     * using the OnValueChanged() feature on the slider, reference the SoundSlider script and use the dynamic float variation of SetSoundVolume() function
     * from the list
     */
    // public void SetSoundVolume(float sliderVolume) {  
    public void SetSoundVolume() {
        float volumeVlaue = soundSlider.value;
        /* 
         * Takes in two parameters - name of the exposed parameter and the value on the slider i.e the volume
         * Need to convert sliderVolume to a logarithmic value. We also set the minimum value on the slider to be 0.0001. Having the minimum value 
         * be 0 will break this whole feature if the sound volume ever does become 0
         */
        audioMixer.SetFloat("SoundVolume", Mathf.Log10(volumeVlaue) * 20);
        PlayerPrefs.GetFloat("SoundSlider", volumeVlaue);
    }
}
