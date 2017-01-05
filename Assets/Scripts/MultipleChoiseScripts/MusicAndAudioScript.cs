using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAndAudioScript : MonoBehaviour {

    [SerializeField]
    AudioSource musicSource;
    AudioClip[] musicArr;
    int musicPlaying;
    [SerializeField]
    AudioSource SFXSource;
    [SerializeField]
    AudioClip SFXRight, SFXWrong;
    bool SFXIsOn = true;

    void Start() {
        int rand = Random.Range(0, 3);
        musicPlaying = rand;
        musicArr = Resources.LoadAll<AudioClip>("AudioMusic/BackgroundMusic");
        musicSource.GetComponent<AudioSource>().clip = musicArr[rand];
        musicSource.Play();
    }

    void Update() {
        //change music
        if(musicSource.mute != true && musicSource.isPlaying == false) {
            musicPlaying++;
            if(musicPlaying > 2) {
                musicPlaying = 0;
            }
            musicSource.GetComponent<AudioSource>().clip = musicArr[musicPlaying];
            musicSource.Play();
        }
    }

    /// <summary>
    /// Toggles the game music
    /// </summary>
    /// <param name="musicButton">music audio source</param>
    public void ToggleMusic(Button musicButton) {
        if(musicSource.mute == false) {
            musicSource.Pause();
            musicSource.mute = true;
            Sprite icon = Resources.Load<Sprite>("Texture/ButtonIcon/musicOff");
            musicButton.GetComponent<Image>().sprite = icon;
        }
        else {
            musicSource.UnPause();
            musicSource.mute = false;
            Sprite icon = Resources.Load<Sprite>("Texture/ButtonIcon/musicOn");
            musicButton.GetComponent<Image>().sprite = icon;
        }
    }

    public void SFXPlayAnswer(bool correct) {
        if(correct == true && SFXIsOn == true) {
            SFXSource.GetComponent<AudioSource>().clip = SFXRight;
            SFXSource.Play();
        }
        else if(SFXIsOn == true) {
            SFXSource.GetComponent<AudioSource>().clip = SFXWrong;
            SFXSource.Play();
        }
    }

    public void ToggleSFX(Button SFXButton) {
        if(SFXIsOn == true) {
            SFXIsOn = false;
            Sprite icon = Resources.Load<Sprite>("Texture/ButtonIcon/SFXOff");
            SFXButton.GetComponent<Image>().sprite = icon;
        }
        else {
            SFXIsOn = true;
            Sprite icon = Resources.Load<Sprite>("Texture/ButtonIcon/SFXOn");
            SFXButton.GetComponent<Image>().sprite = icon;
        }
    }
}
