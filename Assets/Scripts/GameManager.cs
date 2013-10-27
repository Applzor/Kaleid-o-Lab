using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	[HideInInspector]
	public float playerHealth = 100.0f;
	[HideInInspector]
	public float playerHealthMax = 100.0f;
	
	public GameObject healthbar;
	
	// Update is called once per frame
	void Update () {
		float i = playerHealth/playerHealthMax;
		healthbar.transform.localScale = new Vector3(i -0.025f,1-0.1f,1-0.1f);
		
		if (playerHealth <= 0) {
			Application.LoadLevel(0);
		}
	}
}
