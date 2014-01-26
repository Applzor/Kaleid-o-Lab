using UnityEngine;
using System.Collections;

public class Bullets_Particle : MonoBehaviour {

	[HideInInspector]
	public float fDamage = 0;
	
	protected virtual void OnParticleCollision(GameObject other) {
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyAI>().TakeDamage(fDamage);
		}
	}
}
