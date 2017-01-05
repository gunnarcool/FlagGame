using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour {
    [SerializeField]
    GameObject bG;
    Sprite[] frames;
    float framesPerSecond = 10.0f;

	// Use this for initialization
	void Start () {
		frames = Resources.LoadAll<Sprite>("Background/water");
    }
	
	// Update is called once per frame
	void Update () {
        int index = (int)(Time.time * framesPerSecond);
        index = index % frames.Length;
        bG.GetComponent<Image>().sprite = frames[index];
    }
}
