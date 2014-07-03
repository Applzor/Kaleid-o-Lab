using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public float playerScore;
	private GameObject PlayerScore;

	// Use this for initialization
	void Start () {
		PlayerScore = GameObject.Find ("$Score");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerScore.guiText.text = "Score:" + playerScore.ToString ();
	}

}
