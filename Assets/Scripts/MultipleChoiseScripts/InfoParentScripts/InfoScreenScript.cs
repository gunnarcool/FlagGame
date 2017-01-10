using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using simpleJSON;

public class InfoScreenScript : MonoBehaviour {
    [SerializeField]
    GameObject panel;
    [SerializeField]
    Button closeButton;
    [SerializeField]
    Canvas Canv;
    string url = "https://restcountries.eu/rest/v1/name/";


    public void OnInfoButtonClick() {
        panel.GetComponentInChildren<Text>().text = "Loading...";
        StartCoroutine(GetCountryInfo());
        panel.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
    }

    public void OnInfoPanelClick() {
        panel.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }

    IEnumerator GetCountryInfo() {
        WWW www = new WWW(url + Canv.GetComponent<ImageScript>().getFlagName());
        yield return www;
        if(!string.IsNullOrEmpty(www.error)) {
            panel.GetComponentInChildren<Text>().text = "Information not found :(";
        }
        else {
            WriteInfo(www.text);
        }
    }

    void WriteInfo(string infoText) {
         var N = JSON.Parse(infoText);
        //string name = "Name: " + N[0]["name"].ToString() + "\n";
        string capital      = "Capital: " + N[0]["capital"].ToString() + "\n";
        string population   = "Population: " + N[0]["population"].ToString() + "\n";
        string location     = "Location: " + N[0]["latlng"].ToString() + "\n";
        string numericCode  = "Numeric code: " + N[0]["numericCode"].ToString() + "\n";
        string currencies   = "Currency: " + N[0]["currencies"].ToString() + "\n";
        panel.GetComponentInChildren<Text>().text = capital + population + location + numericCode + currencies;
    }
}
