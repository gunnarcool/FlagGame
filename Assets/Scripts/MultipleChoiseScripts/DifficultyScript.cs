using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour {
    [SerializeField]
    Canvas loadingCanvas;

    public static string Continent;
    static bool timeChallenge = false;

    public void OnClick()
    {
        Continent = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        loadingCanvas.enabled = true;
        SceneManager.LoadScene("FlagGame");
    }

    public void OnToggle(string togg) {
        if(togg == "timeChallenge") {
            if(timeChallenge == false) {
                timeChallenge = true;
            }
            else {
                timeChallenge = false;
            }
        }
    }

    public bool getTimeChallenge() {
        return timeChallenge;
    }

    public string getDifficulty()
    {
        return Continent;
    }
}
