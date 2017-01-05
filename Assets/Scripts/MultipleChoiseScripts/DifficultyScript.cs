using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour {
    [SerializeField]
    GameObject Canvas;
    public static string Continent;

    public void OnClick()
    {
        Continent = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        SceneManager.LoadScene("FlagGame");
    }

    public string getDifficulty()
    {
        return Continent;
    }
}
