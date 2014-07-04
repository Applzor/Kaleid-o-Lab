using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

	//	Stats
	protected float damage = 0;
	public float Damage { get { return damage; } set { damage = value; } }

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == Tags.Enemy)
			other.GetComponent<EnemyAI>().TakeDamage(damage);
	}

	void OnParticleCollision(GameObject other) {
		//@IMPRV
		if (other.tag == Tags.Enemy)
			other.GetComponent<EnemyAI>().TakeDamage(damage);
	}
}
