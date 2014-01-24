using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float healthMax;
	protected float healthCurrent;

	public GameObject[] particles;

	void Awake() {
		healthCurrent = healthMax;
	}

	void FixedUpdate() {
		if (healthCurrent <= 0)
			Explode();
	}

	protected void Explode() {
		//	Create Particle Explosion
		for (int i = 0; i < particles.Length; i++) {
			Instantiate(particles[i], transform.position, transform.rotation);
		}
		
		//	Play sound effect

		//	Add to score?
		
		//	Delete bullet last
		Destroy (this.gameObject);
	}

	public void TakeDamage(float damage) {
		healthCurrent -= damage;
	}
}
