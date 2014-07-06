using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour {

	//	Stats
	protected float damage = 0f;
	protected float firerate = 1f;
	protected float cooldown = 0;

	//	Handles
	protected Animator animationController = null;

	protected void Start()
	{
		//	Initalise Data
		UpdateBulletScripts();

		animationController = GetComponent<Animator>();
	}
	protected void Update() 
	{
		Shoot(Input.GetAxis("Fire1"));

		//	Update cooldown timer
		cooldown -= Time.deltaTime;
	}

	public abstract void Shoot(float fire);

	//	Will update relevant stats for the bullets
	//	~Damage
	void UpdateBulletScripts()
	{
		List<Bullets> bulletsScripts = new List<Bullets>();
		foreach (Transform t in transform)
		{
			var component = t.GetComponent<Bullets>();
			if (component != null)
				bulletsScripts.Add(component);
		}

		//	Handles for the scripts to reduce GetComponent calls
		foreach (Bullets script in bulletsScripts)
			script.Damage = damage;
	}
}
