using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

    [SerializeField]
    string IOSID = "1253746";
    [SerializeField]
    string androidID = "1253711";
    string gameID = "1253711";

    void Awake() {
        if (Application.platform == RuntimePlatform.IPhonePlayer) {
            gameID = IOSID;
        }
        else {
            gameID = androidID;
        }
        Advertisement.Initialize(gameID, true);
    }

    public void ShowAd(string zone = "") {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif
        if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady(zone))
            Advertisement.Show(zone, options);
    }
    
    void AdCallbackhandler(ShowResult result) {
        switch (result) {
            case ShowResult.Finished:
                Debug.Log("Ad Finished.");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped");
                break;
            case ShowResult.Failed:
                Debug.Log("I swear this has never happened to me before");
                break;
        }
    }

    //Freezes time for UnityEditor. Ad Bug!
    IEnumerator WaitForAd() {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;
    }
}
