using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagScript : MonoBehaviour {

    [SerializeField]
    Image smallImg, bigImg;
    [SerializeField]
    GameObject flagCounter;
    [SerializeField]
    Canvas Canv;
    Sprite[] sprites;
    int flagNumber;
    string difficulty;
    string flagName;
    List<int> skipList = new List<int>();

    // Use this for initialization
    void Awake () {
        difficulty = GetComponent<DifficultyScript>().getDifficulty();
        if (difficulty == "World") {
            difficulty = "";
        }
        sprites = Resources.LoadAll<Sprite>("Flags/" + difficulty);
        GetRandomFlag();
    }
	
	public void GetRandomFlag() {
        GetFlagNumber();
        bigImg.sprite = sprites[flagNumber];
        bigImg.preserveAspect = true;
        smallImg.sprite = sprites[flagNumber];
        smallImg.preserveAspect = true;
        flagName = FormatFlagName(sprites[flagNumber].name);

        Canv.GetComponent<InputGeneratorScript>().DeleteInput();
        Canv.GetComponent<InputGeneratorScript>().GenerateInputButtons(flagName);
        print(flagName);
        print(flagName.Length);
    }

    void GetFlagNumber() {
        if(skipList.Count >= sprites.Length) {
            GetComponent<EndPanelScript>().openEndPanel();
            return;
        }

        flagNumber = Random.Range(0, (sprites.Length - 1));

        while (skipList.Contains(flagNumber)){
            flagNumber++;
            if(flagNumber > sprites.Length - 1) {
                flagNumber = 0;
            }
        }
        skipList.Add(flagNumber);
        FlagCounter();
    }

    string FormatFlagName(string flagName) {
        flagName = flagName.Replace("_", " ").ToUpper();
        return flagName;
    }

    public void ToggleImage() {
        if(smallImg.isActiveAndEnabled) {
            smallImg.enabled = false;
            bigImg.enabled = true;
        }
        else {
            smallImg.enabled = true;
            bigImg.enabled = false;
        }
    }

    public string GetFlagName() {
        return flagName;
    }

    public void FlagCounter() {
        flagCounter.GetComponentInChildren<Text>().text = skipList.Count + "/" + sprites.Length;
    }

}
