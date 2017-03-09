using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputGeneratorScript : MonoBehaviour {

    [SerializeField]
    GameObject buttonPrefab;
    [SerializeField]
    Transform parent;
    GameObject selectedButt;
    int selectedButtNum;
    GameObject[] buttArr;

    public void GenerateInputButtons(string flagName) {
        float minX = 0;
        float maxX = 0.04f;
        float minY = 0.5f;
        float maxY = 1;
        buttArr = new GameObject[flagName.Length];

        for (int i = 0; i < flagName.Length; i++) {
            if(i == 24) {
                minY = 0;
                maxY = 0.5f;
                minX = 0;
                maxX = 0.04f;
            }
            buttArr[i] = (GameObject)Instantiate(buttonPrefab);
            if (i == 0) {
                SelectButt(buttArr[i], i);
            }
            if (flagName[i] == ' ') {
                buttArr[i].GetComponentInChildren<Text>().text = "-";
                ColorBlock cb = buttArr[i].GetComponent<Button>().colors;
                cb.disabledColor = new Color(1f, 0.5f, 0.15f, 1f);
                buttArr[i].GetComponent<Button>().colors = cb;
                buttArr[i].GetComponent<Button>().interactable = false;
            }
            else {
                buttArr[i].GetComponentInChildren<Text>().text = "*";
                Button b = buttArr[i].GetComponent<Button>();
                GameObject butt = buttArr[i];
                int test = i;
                b.onClick.AddListener(() => SelectButt(butt, test));
            }
            buttArr[i].transform.SetParent(parent);
            buttArr[i].GetComponent<RectTransform>().anchorMin = new Vector2(minX, minY);
            buttArr[i].GetComponent<RectTransform>().anchorMax = new Vector2(maxX, maxY);
            buttArr[i].GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            buttArr[i].GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            buttArr[i].GetComponentInChildren<Text>().resizeTextForBestFit = true;
            buttArr[i].GetComponentInChildren<Text>().fontStyle = FontStyle.Bold;
            maxX = maxX + 0.04f;
            minX = minX + 0.04f;
        }
    }

    public void DeleteInput() {
            var children = new List<GameObject>();
            foreach (Transform child in parent) {
                children.Add(child.gameObject);
            }
            children.ForEach(child => Destroy(child));
        }

    public void SelectButt(GameObject butt, int buttNum) {
        ColorBlock cb = butt.GetComponent<Button>().colors;
        if (selectedButt != null) {
            cb.normalColor = new Color(1f, 1f, 1f, 1f);
            cb.highlightedColor = new Color(1f, 1f, 1f, 1f);
            selectedButt.GetComponent<Button>().colors = cb;
        }
        selectedButtNum = buttNum;
        selectedButt = butt;
        cb.normalColor = new Color(1f, 1f, 0f, 1f);
        cb.highlightedColor = new Color(1f, 1f, 0f, 1f);
        selectedButt.GetComponent<Button>().colors = cb;
    }

    public void NextSelectedButt() {
        if (selectedButtNum + 1 < buttArr.Length) {
            if(buttArr[selectedButtNum + 1].GetComponentInChildren<Text>().text == "-") {
                SelectButt(buttArr[selectedButtNum + 2], selectedButtNum + 2);
            }
            else {
                SelectButt(buttArr[selectedButtNum + 1], selectedButtNum + 1);
            }
        }
    }

    public void ChangeSelectedButtValue(string str) {
        selectedButt.GetComponentInChildren<Text>().text = str;
        NextSelectedButt();
    }

    public void Erase() {
        foreach (GameObject butt in buttArr) {
            if(butt.GetComponentInChildren<Text>().text != "-") {
                butt.GetComponentInChildren<Text>().text = "*";
            }
        }
        SelectButt(buttArr[0], 0);
    }

    public string GetWord() {
        string str = "";
        foreach (GameObject butt in buttArr) {
            if (butt.GetComponentInChildren<Text>().text == "-") {
                str += " ";
            }
            else {
                str += butt.GetComponentInChildren<Text>().text;
            }
        }
        return str;
    }
}