using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour {
    public Image img;
    string flagName;
    Sprite[] sprites;
    List<string> usedFlagList = new List<string>() {"NoFlag", "NoFlag", "NoFlag" };
    int usedFlagInt = 0;

    // Use this for initialization
    void Start () {
        string difficulty = GetComponent<DifficultyScript>().getDifficulty();
        if(difficulty == "World") {
            difficulty = "";
        }
        sprites = Resources.LoadAll<Sprite>("Flags/" + difficulty);
        getFlag();
        //Initialize ButtonScript
        GetComponent<ButtonScript>().Init(flagName);
    }

    /// <summary>
    /// getFlag() finds a random flag in the sprites Array and 
    /// puts it as the main flag image.
    /// <para>After a country has been chosen. It can not be chosen
    /// again for the next three turns.</para>
    /// </summary>
    public void getFlag() {
        int rand = Random.Range(0, (sprites.Length - 1));
        if(!usedFlagList.Contains(sprites[rand].name)) {
            img.sprite = sprites[rand];
            flagName = sprites[rand].name;
            print(flagName);

            usedFlagList[usedFlagInt] = sprites[rand].name;
            usedFlagInt++;
            if(usedFlagInt > 2) {
                usedFlagInt = 0;
            }
        }
        else {
            getFlag();
        }
        
    }

    public string getFlagName() {
        return flagName;
    }

    public string getRandomFlagName() {
        return sprites[Random.Range(0, (sprites.Length - 1))].name;
    }
}
