using UnityEngine;
using System.Collections;

// Serve this database with the Node json-server prompt:
// db.json


public class GetURL : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Create a string variable to store the URL
		string url = "http://localhost:3000/posts";
		//Create a WWW variable to store the WWW request to that URL
		WWW www = new WWW(url);
		//Start a coroutine called "WaitForRequest" with that WWW variable passed in as an argument
		StartCoroutine(WaitForRequest(www));
	}

	//Coroutine WaitForRequest
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null) {
			Debug.Log ("WWW Ok!: " + www.data);
		} else {
			Debug.Log ("WWW Error: " + www.error);
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}



}
