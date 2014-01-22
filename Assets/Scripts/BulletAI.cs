using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour {

	public GameObject debris;
	public GameObject[] particles;
	public float debrisAmount = 7.0f;

	[HideInInspector]
	public float damage;

	private float life = 10;	//	Max life time of a bullet
	private float spawn;

	private static Random rand;

	void Awake() {
		spawn = Time.time;
	}

	void FixedUpdate() {
		//	Destroy bullet if it has been spawned longer than it's life
		if (Time.time > spawn + life)
			Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision e) {

		if (e.transform.tag == "Enemy")
			e.gameObject.GetComponent<EnemyAI>().TakeDamage(damage);

		//if (e.transform.tag != "Player")
		Explode(e);
	}

	void Explode(Collision e) {

		//	Create Explosion Effect
		float force = 250.0f;
		for (int i = 0; i < debrisAmount; i++) {
			GameObject obj = Instantiate(debris, transform.position, transform.rotation) as GameObject;

			Vector3 dir = new Vector3(Random.Range(-1000,1000),Random.Range(-1000,1000),Random.Range(-1000,1000));
			if (dir != Vector3.zero) dir.Normalize();

			obj.rigidbody.AddForce(dir * force);
			//obj.renderer.material = e.gameObject.renderer.material;
		}

		for (int i = 0; i < particles.Length; i++) {
			Instantiate(particles[i], transform.position, transform.rotation);
		}

		//	Play sound effect

		//	Delete bullet last
		Destroy (this.gameObject);		
	}
}
