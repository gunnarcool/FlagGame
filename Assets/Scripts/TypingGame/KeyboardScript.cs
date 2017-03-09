using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour {
    [SerializeField]
    Canvas canv;
    [SerializeField]
    GameObject letters;

    Text[] letterArr;
    bool shiftOn = true;

    void Start() {
        letterArr = letters.GetComponentsInChildren<Text>();
    }

	public void LetterClick(Button butt) {
        canv.GetComponent<InputGeneratorScript>().ChangeSelectedButtValue(butt.GetComponentInChildren<Text>().text);
    }

    public void EraseClick() {
        canv.GetComponent<InputGeneratorScript>().Erase();
    }

    public void SkipClick() {
        canv.GetComponent<FlagScript>().GetRandomFlag();
    }

    public void SubmitClick() {
        canv.GetComponent<SubmitAnsScript>().SubmitAns(canv.GetComponent<InputGeneratorScript>().GetWord());
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
