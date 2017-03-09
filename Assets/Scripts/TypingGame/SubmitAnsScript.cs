using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitAnsScript : MonoBehaviour {

    [SerializeField]
    Canvas canv;

	public void SubmitAns(string str) {
        print(str + " : " + canv.GetComponent<FlagScript>().GetFlagName());
        if(str == canv.GetComponent<FlagScript>().GetFlagName()) {
            print("Correct");
            canv.GetComponent<FlagScript>().GetRandomFlag();
        }
        else {
            print("Wrong");
        }
    }
}
