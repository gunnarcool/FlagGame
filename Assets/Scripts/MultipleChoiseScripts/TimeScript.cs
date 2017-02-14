using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    [SerializeField]
    GameObject timePanel;
    [SerializeField]
    GameObject endPanel;
    [SerializeField]
    Text endText;

    float currCountdownValue;

    // Use this for initialization
    void Start () {
        endPanel.SetActive(false);
        if (GetComponent<DifficultyScript>().getTimeChallenge()) {
            timePanel.SetActive(true);
            StartCoroutine(StartCountdown(60));
        }
        else {
            timePanel.SetActive(false);
        }
    }

    public IEnumerator StartCountdown(float countdownValue = 10) {
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0) {
            timePanel.GetComponentInChildren<Text>().text = "Time: " + currCountdownValue;
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        openEndPanel();
    }

    public void reduceTime(float time) {
        currCountdownValue = currCountdownValue - time;
        if( currCountdownValue <= 0) {
            currCountdownValue = 0;
            openEndPanel();
        }
        timePanel.GetComponentInChildren<Text>().text = "Time: " + currCountdownValue;
    }

    void openEndPanel() {
        endPanel.SetActive(true);
        endText.text = "You got " + GetComponent<AnswerAndPointScript>().getPoints() + " points";
    }


}
