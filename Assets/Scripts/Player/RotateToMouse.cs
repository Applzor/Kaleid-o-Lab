using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {
	
	public AnimationCurve RotationCurve = AnimationCurve.Linear(0, 5, 180, 20);

	// Update is called once per frame
	void Update () {
		//	Gets the mouse position and the objects position (relative to the screen)
		Vector3 T = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
		T.z = T.y;
		T.y = 0;

		float angle = Vector3.Angle (transform.forward, T);
		transform.forward = Vector3.RotateTowards (transform.forward, T.normalized, Mathf.Deg2Rad * RotationCurve.Evaluate(angle), 0);
	}
}
