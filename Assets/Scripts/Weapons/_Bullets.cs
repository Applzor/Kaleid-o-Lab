using UnityEngine;
using System.Collections;

public class _Bullets : MonoBehaviour {

	[HideInInspector]
	public float fDamage = 0;
	
	protected virtual void OnParticleCollision(GameObject other) {
		if (other.tag == _Tags.Enemy) {
			other.GetComponent<EnemyAI>().TakeDamage(fDamage);
		}
	}
}
