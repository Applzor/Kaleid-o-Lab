using UnityEngine;
using System.Collections;

public class Attack_ : MonoBehaviour {

	void Update() {
		if (Input.GetButton("Fire1")) {
			foreach (Transform child in transform) {  
				child.GetComponent<_Weapon>().Shoot();
			}
		}
	}
}
