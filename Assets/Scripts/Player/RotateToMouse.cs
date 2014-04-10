using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {

	public AnimationCurve RotateCurve = AnimationCurve.Linear(0, 3, 180, 10);

	// Update is called once per frame
	void FixedUpdate () {
		//	Gets the mouse position and the objects position (relative to the screen)
		Vector3 T = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
		T.z = T.y;
		T.y = 0;
		T.Normalize ();

		float angle = Vector3.Dot (transform.forward, T);
		angle = Mathf.Acos (angle);
		angle = angle * Mathf.Rad2Deg;
		transform.forward = Vector3.RotateTowards (transform.forward, T.normalized, RotateCurve.Evaluate (angle) * Time.fixedDeltaTime, 0.0f);
	}
}
