using UnityEngine;
using System.Collections;
using SimpleJSON;

// Serve this database with the Node json-server prompt:
// sizedb.json

public class LinkValue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		//Create a string variable to store the URL
		string url = "http://localhost:3000/configs";
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
		
		print (textToParse);
		var N = JSON.Parse (textToParse);
		print ("SimpleJSON" + N.ToString());

		string cityName = N[2]["name"].Value;
		print ("City: " + cityName);

		float popNum = N [2] ["size"].AsFloat;
		print ("Population: " + popNum);

		// Change the size of the cylinder to equal population size
		ChangeSize (popNum);

	}

	void ChangeSize(float populationSize) {

		print ("Got it! " + populationSize);
		transform.localScale = new Vector3 (1.0F, populationSize, 1.0F);

	}

}
