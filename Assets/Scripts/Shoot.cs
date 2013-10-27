using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour {
	
	public GameObject bullet;
	public GameObject shell;
	public float cooldown;
	
	public virtual void ShootGun() { 
		
	}
	
	protected void SpawnShell() {
		Vector3 dir = transform.up + transform.right;
		dir += transform.forward * (Random.Range(-500.0f,500.0f)/1000.0f);
		
		Vector3 spawn = transform.position + (transform.up + transform.right)/2;
		GameObject obj2 = Instantiate(shell, spawn, transform.rotation) as GameObject;
		obj2.rigidbody.AddForce(dir * 100.0f);
		obj2.renderer.material = renderer.material;
	}
}
