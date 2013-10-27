using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public float rotateSpeed = 1.0f;
	public Vector3 axis = Vector3.up;
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(axis, rotateSpeed * Time.deltaTime);
	}
}
