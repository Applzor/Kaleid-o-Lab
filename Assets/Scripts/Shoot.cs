using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour {
	
	public GameObject bullet;
	public GameObject shell;
	public float cooldown;
	public float shellDirection;
	public float force;
	public float damage;
	private float fLastShot;	
	
	public void ShootGun() {
			
		if (Time.time >	fLastShot + cooldown) {
			fLastShot = Time.time;
			audio.Play();
		
			GameObject obj = Instantiate(bullet, transform.position + transform.forward, transform.rotation) as GameObject;
			obj.renderer.material = renderer.material;
			obj.rigidbody.AddForce(transform.forward*force);
			obj.GetComponent<BulletAI>().damage = damage;
			SpawnShell();
		}
	}
	
	protected void SpawnShell() {
		Vector3 side = (shellDirection >= 0) ? transform.right : -transform.right;
		Vector3 dir = transform.up + side;
		dir += transform.forward * (Random.Range(-500.0f,500.0f)/1000.0f);
		
		Vector3 spawn = transform.position + (transform.up + side)/2;
		GameObject obj2 = Instantiate(shell, spawn, transform.rotation) as GameObject;
		obj2.rigidbody.AddForce(dir * 100.0f);
		obj2.renderer.material = renderer.material;
	}
}
