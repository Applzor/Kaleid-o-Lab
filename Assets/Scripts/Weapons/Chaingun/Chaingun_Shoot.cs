using UnityEngine;
using System.Collections;

public class Chaingun_Shoot : _Weapon {

	public override void Shoot() {

        foreach (Transform child in transform)
            if (child.animation != null) 
                child.animation.Play();

		if (timer >= cooldown) {
			timer = 0.0f;

            if (audio != null) audio.Play();
            

            foreach (Transform child in transform)
            {
                if (child.particleSystem) child.particleSystem.Play();
                if (child.GetComponent<_Bullets>()) child.GetComponent<_Bullets>().fDamage = damage;
            }
		}
	}
}
