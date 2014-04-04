using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {
 
	public float RotateSpeed;

	// Update is called once per frame
	void Update () {
		//	Gets the mouse position and the objects position (relative to the screen)
		Vector3 T = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
		T.z = T.y;
		T.y = 0;

		//transform.forward = T.normalized;
		transform.forward = Vector3.RotateTowards (transform.forward, T.normalized, 0.1f, RotateSpeed);
		//transform.forward = Vector3.Lerp (transform.forward, T.normalized, RotateSpeed);
	}
}
