using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float healthMax;
	protected float healthCurrent;

	void Awake() {
		healthCurrent = healthMax;
	}

	void FixedUpdate() {
		if (healthCurrent <= 0)
			Explode();
	}

	protected void Explode() {
		//	Create Particle Explosion
		
		//	Play sound effect

		//	Add to score?
		
		//	Delete bullet last
		Destroy (this.gameObject);
	}

	public void TakeDamage(float damage) {
		healthCurrent -= damage;
	}
}
