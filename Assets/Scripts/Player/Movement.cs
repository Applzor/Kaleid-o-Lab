using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {
	
	public float acceleration;
	
	// Update is called once per frame
	void FixedUpdate () {		
		Vector3 direction = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		direction.Normalize ();

		rigidbody.AddForce(direction  * acceleration * Time.fixedDeltaTime, ForceMode.VelocityChange);		
	}
}
