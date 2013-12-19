using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour {

	[HideInInspector]
	public float damage;

	private float life = 10;	//	Max life time of a bullet
	private float spawn;

	void Awake() {
		spawn = Time.time;
	}

	void FixedUpdate() {
		//	Destroy bullet if it has been spawned longer than it's life
		if (Time.time > spawn + life)
			Explode();
	}

	void OnCollisionEnter(Collision e) {

		if (e.transform.tag == "Enemy")
			e.gameObject.GetComponent<EnemyAI>().TakeDamage(damage);

		if (e.transform.tag != "Player")
			Explode();
	}

	void Explode() {

		//	Create Particle Explosion

		//	Play sound effect

		//	Delete bullet last
		Destroy (this.gameObject);		
	}
}
