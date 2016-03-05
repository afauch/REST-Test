using UnityEngine;
using System.Collections;
using SimpleJSON;

// Serve this database with the Node json-server prompt:
// db.json

public class ParseJSON : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//Create a string variable to store the URL
		string url = "http://localhost:3000/posts?id=2";
		//Create a WWW variable to store the WWW request to that URL
		WWW www = new WWW(url);
		//Start a coroutine called "WaitForRequest" with that WWW variable passed in as an argument
		StartCoroutine(WaitForRequest(www));
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	//Coroutine WaitForRequest
	IEnumerator WaitForRequest(WWW www)
	{

		yield return www;
		// check for errors
		if (www.error == null) {
			Debug.Log ("WWW Ok!: " + www.text);
			//start the "DoParse" function.
			DoParse(www.text);
		} else {
			Debug.Log ("WWW Error: " + www.error);
		}
	}

	void DoParse(string textToParse){

		// print the incoming JSON string, just to make sure we got the request right
		print (textToParse);
		// create a variable to hold the parsed JSON
		var N = JSON.Parse (textToParse);
		// print the parsed JSON, just to make sure it worked
		print ("SimpleJSON" + N.ToString());
		// create a string to hold the specific value we're looking for
		// NOTE: even though my HTTP URL above contained a "?id=2" query
		// it was still necessary to include the index number - N[0] - before
		// grabbing any values
		string authorName = N[0]["author"].Value;
		// print to console to confirm that it worked
		print ("Author: " + authorName);
		// Here's the usage for values as integers
		int postNum = N [0] ["id"].AsInt;
		print ("ID Number: " + postNum);

	}

}
