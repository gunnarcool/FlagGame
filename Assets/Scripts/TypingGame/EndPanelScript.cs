using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndPanelScript : MonoBehaviour {

    [SerializeField]
    GameObject endPanel;
    [SerializeField]
    Text endText;

    public void endGame() {
        SceneManager.LoadScene("StartMenu");
    }

    public void playAgain() {
        SceneManager.LoadScene("TypingGame");
    }

    public void openEndPanel() {
        endPanel.SetActive(true);
        endText.text = "You have finished all countries. Play again?";
    }
}
