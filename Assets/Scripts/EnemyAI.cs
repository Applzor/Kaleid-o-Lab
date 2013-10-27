using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class EnemyAI : MonoBehaviour {
	
	public float Health = 100.0f;
	public float fAcceleration;
	public float fVelocityMax;
	public GameObject particle;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Health <= 0) {
			renderer.enabled = false;
			collider.enabled = false;	
			if (!audio.isPlaying)
				Destroy(gameObject);
		}
		
		//	Track Towards the Player
		Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
		dir.Normalize();
		rigidbody.AddForce(dir  * fAcceleration, ForceMode.Force);		
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, fVelocityMax);
	}
	
	public void TakeDamage(float _damage) {
		Health-=_damage;
		if (Health <= 0) {
			audio.Play();
			
			//	Spawn some debris
			for (int i = 0; i < 6; i++) {
				Vector3 dir = transform.up;
				dir += transform.forward * (Random.Range(-500.0f,500.0f)/1000.0f);
				dir += transform.right * (Random.Range(-500.0f,500.0f)/1000.0f);
				
				GameObject obj = Instantiate(particle, transform.position, transform.rotation) as GameObject;
				obj.rigidbody.AddForce(dir * 250.0f);
				obj.renderer.material = gameObject.renderer.material;
			}				
		}
	}
}
