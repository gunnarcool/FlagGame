using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelectionScript : MonoBehaviour {
    [SerializeField]
    Canvas menuCanvas, multipleChoiceCanvas, loadingCanvas, typingGameCanvas;

    void Start() {
        loadingCanvas.enabled = false;
        menuCanvas.enabled = true;
        multipleChoiceCanvas.enabled = false;
        typingGameCanvas.enabled = false;
    }

    public void OnClick() {
        menuCanvas.enabled = false;
        multipleChoiceCanvas.enabled = true;
    }

    public void OnTypingGameClick() {
        menuCanvas.enabled = false;
        typingGameCanvas.enabled = true;
    }
}
