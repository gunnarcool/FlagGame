using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitAnsScript : MonoBehaviour {

    [SerializeField]
    Canvas canv;

	public void SubmitAns(InputField inputF) {
        if(inputF.text == canv.GetComponent<FlagScript>().GetFlagName()) {
            print("Correct");
            inputF.text = "";
            canv.GetComponent<FlagScript>().GetRandomFlag();
        }
        else {
            print("Wrong");
        }
    }
}
