using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public int zoomSpeed = 2;
	public Vector2 zoomMin = new Vector2(-5, 5);
	public Vector2 zoomMax = new Vector2(-30, 30);

	private GameObject attach;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		attach = GameObject.Find ("Player");
		offset = attach.transform.position - transform.position;
	}

	void FixedUpdate() {

		//	Move the camera smoothly following the player
		Vector3 newPos = attach.transform.position - offset;
		newPos.y = -offset.y;		
		Vector3 currentPos = transform.position;		
		transform.position = Vector3.Slerp(currentPos, newPos, Time.fixedDeltaTime*2);

		// Zoom Camera (Offset)
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			offset.y += zoomSpeed;
			offset.z -= zoomSpeed;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			offset.y -= zoomSpeed;
			offset.z += zoomSpeed;
		}
		offset.y = (offset.y > zoomMin.x) ? zoomMin.x : (offset.y < zoomMax.x) ? zoomMax.x : offset.y;
		offset.z = (offset.z < zoomMin.y) ? zoomMin.y : (offset.z > zoomMax.y) ? zoomMax.y : offset.z;
		
	}
}
