using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float healthMax;
	protected float healthCurrent;

	public GameObject[] particles;

	protected GameObject gameManager;

	void Awake() {
		healthCurrent = healthMax;
	}

	void Start() {
		gameManager = GameObject.Find ("$GameManager");
	}

	void FixedUpdate() {
		if (healthCurrent <= 0)
			Explode();
	}

	protected void Explode() {
		//	Create Particle Explosion
		for (int i = 0; i < particles.Length; i++) {
			Instantiate(particles[i], transform.position, Quaternion.Euler(-90,0,transform.rotation.eulerAngles.z));
		}
		
		//	Play sound effect

		//	Add to score?
		gameManager.transform.GetComponent<_GameManager> ().playerScore++;
		
		//	Delete bullet last
		Destroy (this.gameObject);
	}

	public void TakeDamage(float damage) {
		healthCurrent -= damage;
	}
}
