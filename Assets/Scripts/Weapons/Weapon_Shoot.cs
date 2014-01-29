using UnityEngine;
using System.Collections;

public class Weapon_Shoot : MonoBehaviour {
	
	public void Shoot(float damage) {	

		if (audio != null) {
			audio.Play();
		}
		
		if (animation != null) {
			animation.Play();
		}
		
		foreach (Transform child in transform) {
			if (child.particleSystem != null)
				child.particleSystem.Play();
			if (child.GetComponent<Bullets_Particle>() != null)
				child.GetComponent<Bullets_Particle>().fDamage = damage;

		}			
	}
}
