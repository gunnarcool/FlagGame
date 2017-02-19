using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour {
    [SerializeField]
    Canvas canv;
    [SerializeField]
    GameObject letters;
    [SerializeField]
    InputField inputF;

    Text[] letterArr;
    bool shiftOn = true;

    void Start() {
        inputF.enabled = false;
        letterArr = letters.GetComponentsInChildren<Text>();
    }

	public void LetterClick(Button butt) {
        inputF.text = inputF.text + butt.GetComponentInChildren<Text>().text;
    }

    public void BackspaceClick() {
        if(inputF.text.Length > 0) {
            inputF.text = inputF.text.Remove(inputF.text.Length - 1);
        }
    }

    public void SpaceClick() {
        inputF.text = inputF.text + " ";
    }

    public void SkipClick() {
        canv.GetComponent<FlagScript>().GetRandomFlag();
    }

    public void SubmitClick() {
        canv.GetComponent<SubmitAnsScript>().SubmitAns(inputF);
    }

    public void ShiftClick() {
        if (shiftOn == true) {
            shiftOn = false;
            foreach (Text letter in letterArr) {
                letter.text = letter.text.ToLower();
            }
        }
        else {
            foreach (Text letter in letterArr) {
                shiftOn = true;
                letter.text = letter.text.ToUpper();
            }
        }
    }
}
