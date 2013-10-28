using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	public GameObject attach;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = attach.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 newPos = attach.transform.position - offset;
		newPos.y = 20.0f;
		
		Vector3 currentPos = transform.position;
		
		transform.position = Vector3.Slerp(currentPos, newPos, 0.05f);
	}
}
