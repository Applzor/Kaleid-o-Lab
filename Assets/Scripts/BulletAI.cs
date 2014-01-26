using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour {

	public GameObject sparks;
	public GameObject debris;

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

		Debug.Log ("Dir: " + transform.forward);
		Debug.Log ("Nrml: " + e.contacts [0].normal);


		var reflect = Vector3.Reflect (transform.forward, e.contacts [0].normal);
		var rot = Quaternion.FromToRotation (transform.forward, reflect);

		Instantiate(sparks, transform.position, Quaternion.Euler(0,rot.eulerAngles.y,0));
		Instantiate(debris, transform.position, Quaternion.Euler(-90,transform.rotation.eulerAngles.y,0));

		//	Play sound effect

		//	Delete bullet last
		Destroy (this.gameObject);		
	}
}
