using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class PostRequestScript : MonoBehaviour {

    string url = "https://api.mlab.com/api/1/databases/flag_game/collections/FGCollection?apiKey=DyztOMYUMvpGDvD3GND_YY_cueZt_V1I";
	
	public void Click() {
        //StartCoroutine(PostRequest());
        //StartCoroutine(GETRequest());
        //StartCoroutine(PutRequest());
    }

    IEnumerator PutRequest() {
        string jsonStr = "{\"_id\" : \"5866c70fbd966f6cf3b0db50\", \"X\" : 3, \"Y\" : 5}";
        //string jsonStr = "{\"_id\" : \"5866c70fbd966f6cf3b0db49\", \"X\" : 8}";
        //string jsonStr = "{\"X\" : 200}";
        var body = Encoding.UTF8.GetBytes(jsonStr);
        using (UnityWebRequest www = UnityWebRequest.Put(url, body)) {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.Send();
            if (www.isError) {
                print(www.error);
            }
            else {
                print(www.downloadHandler.text);
            }
        }
    }

    IEnumerator GETRequest() {
        using (UnityWebRequest www = UnityWebRequest.Get(url)) {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return null;
            if (www.error == null) {
                print(www.downloadHandler.text);
            }
            else {
                Debug.Log("WWW Error: " + www.error);
            }
        }
    }

    IEnumerator PostRequest() {
        WWWForm form = new WWWForm();
        form.AddField("Y", "50");
        form.headers["content-type"] = "application/json";
        WWW www = new WWW(url, form);
        
        yield return www;

        if (www.error != null) {
            print("Error downloading: " + www.error);
        }
        else {
            Debug.Log(www.text);
        }
    }

    IEnumerator UnityPostRequest() {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post(url, form)) {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.Send();

            if (www.isError) {
                Debug.Log(www.error);
            }
            else {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

}
