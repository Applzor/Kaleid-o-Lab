using UnityEngine;
using System.Collections;

public class ShellAI : MonoBehaviour {

	public float life;
	private float spawn;

	void Awake() {
		spawn = Time.time;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time > spawn + life)
			Destroy(this.gameObject);
	}
}
