using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	public bool shellDir;

	[HideInInspector]
	public float bulletForce;
	[HideInInspector]
	public float shellForce;
	[HideInInspector]
	public GameObject bullet;
	[HideInInspector]
	public GameObject shell;

	public void Shoot(float _bDamage) {
	
		//audio.Play();
		animation.Play();

		SpawnBullet(_bDamage);
		SpawnShell();
	}

	protected void SpawnBullet(float _bDamage) {
		//	Creating a bullet to be shot from the weapon
		GameObject obj = Instantiate (bullet, transform.position + (transform.forward * 1), transform.rotation) as GameObject;
		obj.renderer.material = renderer.material;
		obj.GetComponent<BulletAI> ().damage = _bDamage;
		obj.rigidbody.AddForce (transform.forward * bulletForce);
	}

	protected void SpawnShell() {
		Vector3 side = (shellDir) ? transform.right : -transform.right;
		Vector3 dir = transform.up + side;
		dir += transform.forward * (Random.Range(-500.0f,500.0f)/1000.0f);		
		Vector3 spawn = transform.position + (transform.up + side)/2;

		//	Create a shell and have it shoot out to the side
		GameObject obj = Instantiate(shell, spawn, transform.rotation) as GameObject;
		obj.rigidbody.AddForce(dir * shellForce);
		obj.renderer.material = renderer.material;
	}
}
