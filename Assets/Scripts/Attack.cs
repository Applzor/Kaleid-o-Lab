using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton(0)) {
			foreach (Transform child in transform) { 
				child.GetComponent<Shoot>().ShootGun();
			}
		}	
	}
}
