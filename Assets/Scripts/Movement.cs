using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {
	
	public float fAcceleration;
	public float fVelocityMax;
	
	// Use this for initialization
	void Start () {
		rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {		
		//	Get the direction of the Player (Relative to World Space)
		Vector3 v3Direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//Vector3 v3Direction = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
		v3Direction.Normalize();		
		
		rigidbody.AddForce(v3Direction  * fAcceleration, ForceMode.Force);		
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, fVelocityMax);
	}
}
