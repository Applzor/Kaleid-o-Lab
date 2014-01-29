using UnityEngine;
using System.Collections;

public class _Weapon_Blue : _Weapon {

	private short attach = 0;

	public override void Shoot() {	
		
		if (timer >= cooldown) {
			timer = 0;

			if (transform.GetChild(attach).GetComponent<Weapon_Shoot>()) {
				transform.GetChild(attach).GetComponent<Weapon_Shoot>().Shoot(damage);
				attach++;
			}			

			if (attach > transform.childCount - 1)
				attach = 0;
		}
	}
}
