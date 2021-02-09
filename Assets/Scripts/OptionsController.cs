using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour{

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficutly = 0.0f;

    void Start(){
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update(){
        //looking for the music player, if we don't start from the splash screen we will get an 'warning' message
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) {
            musicPlayer.SetVolume(volumeSlider.value);
        } else {
            Debug.LogWarning("No music player found. did you start from splash screen?");
        }  
    }

    public void SaveAndExit() {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenuScene();
    }

    public void SetToDefaults() {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficutly;
    }
}
