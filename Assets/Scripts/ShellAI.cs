using UnityEngine;
using System.Collections;

public class ShellAI : MonoBehaviour {

	float spawn;
	float life = 0.5f;
	public ParticleSystem emitter;
	
	void Awake() {
		spawn = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > spawn + life)
			Destroy(this.gameObject);
	}
}
