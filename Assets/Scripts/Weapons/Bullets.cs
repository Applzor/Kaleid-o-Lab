using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

	protected float damage = 0;

	public float Damage { get { return damage; } set { damage = value; } }
	
	protected virtual void OnParticleCollision(GameObject other) {
		if (other.tag == Tags.Enemy) {
			other.GetComponent<EnemyAI>().TakeDamage(damage);
		}
	}
}
