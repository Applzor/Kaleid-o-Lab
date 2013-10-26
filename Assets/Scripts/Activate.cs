using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {
	void ActivatedOrb(string s_Tag) {
		if (s_Tag != tag)
			return;
		
		Debug.Log (s_Tag + " Activated");
		collider.enabled = true;
		renderer.enabled = true;
	}
}
