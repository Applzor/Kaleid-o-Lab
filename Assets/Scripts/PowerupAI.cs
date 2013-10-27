using UnityEngine;
using System.Collections;

public class PowerupAI : MonoBehaviour {
	
	public GameObject [] upgrades;
	float distance = 0;
	float turnAround = 30;
	bool up = true;
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			foreach (GameObject upgrade in upgrades) {
				GameObject obj = Instantiate(upgrade, other.transform.position, other.transform.rotation) as GameObject;
				obj.transform.parent = other.transform;
				Vector3 offset = obj.transform.position;
				offset += upgrade.transform.position;
				obj.transform.position = offset;
			}
		}
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos;
		
		if (up) {
			if (distance > turnAround)
				up=false;
			newPos = Vector3.Lerp(transform.position, transform.position+transform.up, 0.01f);
			distance++;
		}
		else {
			if (distance < -turnAround)
				up=true;
			newPos = Vector3.Lerp(transform.position, transform.position+(-transform.up), 0.01f);
			distance--;	
		}		
		transform.position = newPos;
	}
}
