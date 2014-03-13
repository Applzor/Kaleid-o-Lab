using UnityEngine;
using System.Collections;

public class PlatformRaise : MonoBehaviour {

	public float range;
	public float speed;

	private GameObject Player;
	private Vector3 raisedPos;
	private Vector3 loweredPos;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		raisedPos = transform.position;
		loweredPos = raisedPos - new Vector3 (0, 10, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//	Determine if player is in range for the platform to raise or lower
		float distance = Vector3.Magnitude (Player.transform.position - raisedPos);
		if (distance <= range)
			Raise ();
		else
			Lower();
	}

	void Raise() {
		Vector3 pos = transform.position;
		pos = Vector3.Lerp (pos, raisedPos, speed);
		transform.position = pos;
	}

	void Lower() {
		Vector3 pos = transform.position;
		pos = Vector3.Lerp (pos, loweredPos, speed);
		transform.position = pos;
	}
}
