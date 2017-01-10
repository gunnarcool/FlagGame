using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
    [SerializeField]
    Button butt1, butt2, butt3, butt4, nextQuestionButt;
    Button[] butts;
    int correctAns;
    string flagName;
    bool wasWrong = false;
    Button selectedButt;

    void Start() {
        nextQuestionButt.gameObject.SetActive(false);
    }

    //Called by ImageScript Start()
    public void Init (string flag) {
        butts = new Button [] { butt1, butt2, butt3, butt4 };
        flagName = GetComponent<ImageScript>().getFlagName();
        makeCorrectButt(flagName);
        makeRandomNames();
    }

    public void checkCorrect(Button butt) {
        if (butt.GetComponentInChildren<Text>().text == flagName.Replace("_", " ")) {
            GetComponent<AnswerAndPointScript>().isCorrect();
            nextQuestion();
        }
        else {
            wasWrong = true;
            selectedButt = butt;
            GetComponent<AnswerAndPointScript>().isWrong();
            butts[correctAns].GetComponent<Image>().color = Color.green;
            selectedButt.GetComponent<Image>().color = Color.red;
            nextQuestionButt.gameObject.SetActive(true);
            
            StartCoroutine(nextQuestionButtonTimer());
        }
    }

    //corutines stack :(
    IEnumerator nextQuestionButtonTimer() {
        yield return new WaitForSecondsRealtime(2);
        if(wasWrong == true) {
            nextQuestionButton();
        }
    }

    public void nextQuestionButton() {
        wasWrong = false;
        nextQuestionButt.gameObject.SetActive(false);
        butts[correctAns].GetComponent<Image>().color = Color.white;
        selectedButt.GetComponent<Image>().color = Color.white;
        nextQuestion();
    }

    void nextQuestion() {
        GetComponent<ImageScript>().getFlag();
        flagName = GetComponent<ImageScript>().getFlagName();
        makeCorrectButt(flagName);
        makeRandomNames();
    }

    void makeCorrectButt(string flag) {
        correctAns = Random.Range(0, 4);
        butts[correctAns].GetComponentInChildren<Text>().text = flag.Replace("_", " ");
    }

    void makeRandomNames() {
        List<string> nameList = new List<string>();
        nameList.Add(butts[correctAns].GetComponentInChildren<Text>().text);
        string newName;

        for(int i = 0; i <= 3; i++) {
            newName = GetComponent<ImageScript>().getRandomFlagName().Replace("_", " ");
            if (i == correctAns) {
            }
            else if (nameList.Contains(newName)) {
                i--;
            }
            else {
                nameList.Add(newName);
                butts[i].GetComponentInChildren<Text>().text = newName;
            }
        }
    }
}
