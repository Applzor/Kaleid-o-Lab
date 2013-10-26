using UnityEngine;
using System.Collections;

public class PickUpOrb : MonoBehaviour {
	
	void OnTriggerEnter() {
		//	Activate all the Platforms of that Colour
		GameObject.Find("Platforms").BroadcastMessage("ActivatedOrb", tag, SendMessageOptions.RequireReceiver);
	}
}
