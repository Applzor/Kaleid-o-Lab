using UnityEngine;
using System.Collections;

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
	}

}
