using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chaingun : Weapon {

	//	Particles
	public GameObject[] bulletEmitter;
	public GameObject[] shellEmitter;
	public GameObject[] effectEmitter;

	public override void Shoot(float fire) 
	{
		animationController.SetFloat("Fire", fire);

		if (fire == 1 && cooldown <= 0)
		{
			//	Play particles
			foreach (GameObject obj in bulletEmitter)
				obj.particleSystem.Play();
			foreach (GameObject obj in shellEmitter)
				obj.particleSystem.Play();
			foreach (GameObject obj in effectEmitter)
				obj.particleSystem.Play();

			//	Reset Timer
			cooldown = rate;
		}
	}
}
