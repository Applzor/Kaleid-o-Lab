using UnityEngine;
using System.Collections;
using System.IO;

public class _GameManager : MonoBehaviour {

	[HideInInspector]
	public float playerScore;
	private GameObject _PlayerScore;

	// Use this for initialization
	void Start () {
		_PlayerScore = GameObject.Find ("$Score");
	}
	
	// Update is called once per frame
	void Update () {
		_PlayerScore.guiText.text = "Score:" + playerScore.ToString ();

		if (Input.GetKeyDown(KeyCode.F1))
			Save ();
	}

	void Save() {
		string fileName = "MyFile.txt";

		StreamWriter sr;
		if (!File.Exists(fileName)) {
			print ("Created" + fileName);
			sr = File.CreateText(fileName);	
		}
		else {
			print ("Loaded" + fileName);
			sr = File.AppendText(fileName);
		}
 
		sr.WriteLine ("This is my file.");
		sr.WriteLine ("I can write ints {0} or floats {1}, and so on.", 1, 4.2);
		sr.Close();
	}
}
