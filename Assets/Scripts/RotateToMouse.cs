using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {
 
	// Update is called once per frame
	void Update () {
		//	Gets the mouse position and the objects position (relative to the screen)
		Vector3 T = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
		T.z = T.y;
		T.y = 0;

    	transform.forward = T;
	}
}
