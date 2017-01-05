using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
    [SerializeField]
    Button butt1, butt2, butt3, butt4;
    Button[] butts;
    int correctAns;
    string flagName;

    //Called by ImageScript Start()
    public void Init (string flag) {
        butts = new Button [] { butt1, butt2, butt3, butt4 };
        flagName = GetComponent<ImageScript>().getFlagName();
        makeCorrectButt(flagName);
        makeRandomNames();
    }

    public void getChoices(Button selectedButt) {
        checkCorrect(selectedButt);
        flagName = GetComponent<ImageScript>().getFlagName();
        makeCorrectButt(flagName);
        makeRandomNames();
    }

    void checkCorrect(Button selectedButt) {
        if (selectedButt.GetComponentInChildren<Text>().text == flagName.Replace("_", " ")) {
            GetComponent<AnswerAndPointScript>().isCorrect();
        }
        else {
            GetComponent<AnswerAndPointScript>().isWrong();
        }
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
