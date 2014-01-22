using UnityEngine;
using System.Collections;

public class Attack_ : MonoBehaviour {

	public float damage;
	public float cooldown;

	public float bulletForce;
	public float shellForce;
	
	public GameObject bullet;
	public GameObject shell;

	private float lastShot;

	void Awake() {
		foreach (Transform child in transform) {  
			child.GetComponent<Weapon>().bulletForce = bulletForce;
			child.GetComponent<Weapon>().bullet = bullet;
			child.GetComponent<Weapon>().shellForce = shellForce;
			child.GetComponent<Weapon>().shell = shell;
		}
	}
	
	void Update() {
		if (Time.time > lastShot + cooldown) {
			if (Input.GetButton("Fire1") && transform.parent.tag == "Player") {
				lastShot = Time.time;
				foreach (Transform child in transform) {  
					child.GetComponent<Weapon>().Shoot(damage);
				}
			}
		}
	}
}
