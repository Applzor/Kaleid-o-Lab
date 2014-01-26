using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack_ : MonoBehaviour {

	public float damage;
	public float cooldown;

	private float timer;
	private List<Transform>childsOfGameobject = new List<Transform>();
	

	void Start() {
		foreach (Transform child in transform) {
			child.GetComponentInChildren<Bullets_Particle> ().fDamage = damage;
		}
	}
	
	void Update() {
		timer += Time.deltaTime;
		if (timer >= cooldown) {
			timer = 0;
			if (Input.GetButton("Fire1") && transform.parent.tag == "Player") {
				foreach (Transform child in transform) {  
					child.GetComponent<_Weapon>().Shoot();
				}
			}
		}
	}
	

	private List<Transform> GetAllChilds(Transform transformForSearch) {
		List<Transform> getedChilds = new List<Transform>();
		
		foreach (Transform trans in transformForSearch.transform)
		{
			//Debug.Log (trans.name);
			GetAllChilds ( trans.transform );
			childsOfGameobject.Add ( trans.transform );       
		}   
		return getedChilds;
	}
}
