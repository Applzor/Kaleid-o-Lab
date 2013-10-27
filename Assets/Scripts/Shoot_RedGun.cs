using UnityEngine;
using System.Collections;

public class Shoot_RedGun : Shoot {
		
	private float fLastShot;
	public override void ShootGun() {
		if (Time.time >	fLastShot + cooldown) {
			fLastShot = Time.time;
			audio.Play();
		
			GameObject obj = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
			obj.renderer.material = renderer.material;
			obj.rigidbody.AddForce(transform.forward*1500.0f);
			SpawnShell();
		}
	}
}
