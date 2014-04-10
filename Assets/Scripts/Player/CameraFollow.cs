using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public AnimationCurve FollowCurve = AnimationCurve.Linear(0,1,10,50);

	public float zoomSpeed = 2.0f;
	public float zoomOutMax = 3.0f;
	public float zoomInMax = 3.0f;
	private Vector3 offsetStart;
	
	private GameObject cam;
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		cam = Camera.main.gameObject;
		offset = offsetStart = transform.position - cam.transform.position;
	}
	
	void FixedUpdate() {
		
		Follow ();
		Zoom ();		
	}

	void Follow() {
		//	Move the camera smoothly following the player
		Vector3 newPos = transform.position - offset;
		newPos.y = -offset.y;                
		Vector3 currentPos = cam.transform.position;                
		
		//	
		float distance = Vector3.Magnitude (newPos - currentPos);
		distance = FollowCurve.Evaluate (distance);
		cam.transform.position = Vector3.MoveTowards(currentPos, newPos, distance * Time.fixedDeltaTime);
	}

	void Zoom() {
		//	Zoom Camera (Offset)
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			Vector3 dir = cam.transform.forward * -1;
			offset += dir * zoomSpeed;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			Vector3 dir = cam.transform.forward;
			offset += dir * zoomSpeed;
		}
		
		//	Ensure zoom doesn't exceed its bounds
		if (offsetStart.y - offset.y > zoomOutMax) {
			offset = ((cam.transform.forward) * zoomOutMax) + offsetStart;
		}
		else if (offsetStart.y - offset.y < -zoomInMax) {
			offset = ((cam.transform.forward) * -zoomInMax) + offsetStart;
		}
	}
}