using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float slerpSpeed = 3.0f;
	public float zoomSpeed = 2.0f;
	public float zoomOutMax = 3.0f;
	public float zoomInMax = 3.0f;
	private Vector3 offsetStart;
	
	private GameObject attach;
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		attach = GameObject.Find ("Player");
		offset = attach.transform.position - transform.position;
		offsetStart = attach.transform.position - transform.position;
	}
	
	void FixedUpdate() {
		
		//        Move the camera smoothly following the player
		Vector3 newPos = attach.transform.position - offset;
		newPos.y = -offset.y;                
		Vector3 currentPos = transform.position;                
		transform.position = Vector3.Slerp(currentPos, newPos, Time.fixedDeltaTime*slerpSpeed);
		
		// Zoom Camera (Offset)
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			Vector3 dir = transform.forward * -1;
			offset += dir * zoomSpeed;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			Vector3 dir = transform.forward;
			offset += dir * zoomSpeed;
		}
		
		//        Ensure zoom doesn't exceed its bounds
		if (offsetStart.y - offset.y > zoomOutMax) {
			offset = ((transform.forward) * zoomOutMax) + offsetStart;
		}
		else if (offsetStart.y - offset.y < -zoomInMax) {
			offset = ((transform.forward) * -zoomInMax) + offsetStart;
		}
		
	}
}