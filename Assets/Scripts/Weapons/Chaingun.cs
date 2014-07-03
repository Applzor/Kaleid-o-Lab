using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chaingun : Weapon {

	public override void Shoot(float fire) 
	{
		animationController.SetFloat("Fire", fire);
		base.Shoot(fire);
	}
}
