using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BulletAI : MonoBehaviour {
	
	[HideInInspector]
	public float damage;
	public GameObject particle;
	public float explosionSize = 3.0f;
	bool finished = false;
	
	void FixedUpdate () {
		//	Destroy the bullet
		if (!audio.isPlaying && finished)
			Destroy(gameObject);	
	}
	
	void OnCollisionEnter(Collision other) {
		//	Have the enemy take damage
		if (other.gameObject.tag == "Enemy")
			other.gameObject.GetComponent<EnemyAI>().TakeDamage(damage);	
		
		audio.Play();
		renderer.enabled = false;
		collider.enabled = false;
		GetComponent<TrailRenderer>().enabled = false;
		
		finished = true;
		
		//	Spawn some debris
		for (int i = 0; i < explosionSize; i++) {
			Vector3 dir = transform.up;
			dir += transform.forward * (Random.Range(-500.0f,500.0f)/1000.0f);
			dir += transform.right * (Random.Range(-500.0f,500.0f)/1000.0f);
			
			GameObject obj = Instantiate(particle, transform.position, transform.rotation) as GameObject;
			Vector3 newScale = obj.transform.localScale;
			obj.transform.localScale = newScale * 0.5f;
			obj.rigidbody.AddForce(dir * 250.0f);
			obj.renderer.material = other.gameObject.renderer.material;
		}	
	}
}
