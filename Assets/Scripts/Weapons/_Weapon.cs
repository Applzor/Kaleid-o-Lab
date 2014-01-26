using UnityEngine;
using System.Collections;

public class _Weapon : MonoBehaviour {

	public virtual void Shoot() {		
		if (audio != null) {
			audio.Play();
		}

		if (animation != null) {
			animation.Play();
		}

		foreach (Transform child in transform) {
			if (child.particleSystem != null) {
				child.particleSystem.Play();
			}
		}
	}
}
