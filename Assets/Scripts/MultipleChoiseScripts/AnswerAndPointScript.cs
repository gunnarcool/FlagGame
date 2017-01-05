using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerAndPointScript : MonoBehaviour {
    [SerializeField]
    GameObject map;
    [SerializeField]
    Text points;

    int intPoints = 0;
    int tfAns = 0;
    float lerpTime = 0;
    GameObject audioMusicParent;

    void Start() {
        points.text = intPoints.ToString();
        audioMusicParent = GameObject.Find("SettingsParent");
    }

    void Update() {
        if(tfAns == 1) {
            wrongAnimation();
        }
        else if(tfAns == 2) {
            rightAnimation();
        }
    }
	
    public void isCorrect() {
        tfAns = 2;
        lerpTime = 0;
        intPoints++;
        points.text = intPoints.ToString();
        audioMusicParent.GetComponent<MusicAndAudioScript>().SFXPlayAnswer(true);
    }

    public void isWrong() {
        tfAns = 1;
        lerpTime = 0;
        audioMusicParent.GetComponent<MusicAndAudioScript>().SFXPlayAnswer(false);
    }

    void wrongAnimation() {
        Color startColor = Color.red;
        Color endColor = Color.grey;
        map.transform.GetComponent<Image>().color = Color.Lerp(startColor, endColor, lerpTime);
        lerpTime += 0.01f;
        if(lerpTime > 1) {
            lerpTime = 0;
            tfAns = 0;
        }
    }

    void rightAnimation() {
        Color startColor = Color.green;
        Color endColor = Color.grey;
        map.transform.GetComponent<Image>().color = Color.Lerp(startColor, endColor, lerpTime);
        lerpTime += 0.01f;
        if (lerpTime > 1) {
            lerpTime = 0;
            tfAns = 0;
        }
    }
}
