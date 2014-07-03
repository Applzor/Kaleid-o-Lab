using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour {

	//	Stats
	public float damage = 0f;
	public float rate = 1f;
	protected float cooldown = 0;

	//	Particles
	public GameObject[] bulletEmitter;
	public GameObject[] shellEmitter;
	public GameObject[] effectEmitter;
	protected List<Bullets> bulletsScripts;

	protected Animator animationController = null;

	void Start()
	{
		//	Initalise Data
		bulletsScripts = new List<Bullets>();
		FindBulletScripts();

		animationController = GetComponent<Animator>();
	}
	void Update() 
	{
		Shoot(Input.GetAxis("Fire1"));

		//	Update cooldown timer
		cooldown -= Time.deltaTime;
	}

	public virtual void Shoot(float fire)
	{
		if (fire <= 0)
			return;

		if (cooldown <= 0)
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

	void FindBulletScripts()
	{
		bulletsScripts.Clear();
		foreach (GameObject obj in bulletEmitter)
		{
			var component = obj.GetComponent<Bullets>();
			if (component != null)
				bulletsScripts.Add(component);
		}

		//	Handles for the scripts to reduce GetComponent calls
		foreach (Bullets script in bulletsScripts)
			script.Damage = damage;
	}
}
