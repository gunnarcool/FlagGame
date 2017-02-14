using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSelectionScript : MonoBehaviour {
    [SerializeField]
    Canvas menuCanvas, multipleChoiceCanvas, loadingCanvas;

    void Start() {
        loadingCanvas.enabled = false;
        menuCanvas.enabled = true;
        multipleChoiceCanvas.enabled = false;
    }

    public void OnClick() {
        menuCanvas.enabled = false;
        multipleChoiceCanvas.enabled = true;
    }
}
