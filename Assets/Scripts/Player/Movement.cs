using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {
	
	public float Acceleration;
	public float VelocityMax;
	
	// Use this for initialization
	void Awake () {
		rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {		
		//	Get the direction based on player input
		Vector3 direction = Vector3.zero;
		if (Input.GetKey (KeyCode.A))
			direction.x -= 1;
		if (Input.GetKey (KeyCode.D))
			direction.x += 1;
		if (Input.GetKey (KeyCode.W))
			direction.z += 1;
		if (Input.GetKey (KeyCode.S))
			direction.z -= 1;

		direction = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		direction.Normalize ();

		float movementSpeed = Acceleration * Time.fixedDeltaTime;
		rigidbody.AddForce(direction  * movementSpeed, ForceMode.Acceleration);		
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, VelocityMax);
		//if (direction == Vector3.zero)
		//	rigidbody.velocity = Vector3.Lerp (rigidbody.velocity, Vector3.zero, 0.15f);
	}
}
