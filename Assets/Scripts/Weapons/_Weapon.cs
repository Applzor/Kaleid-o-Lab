using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class _Weapon : MonoBehaviour {

	public float damage;
	public float cooldown;
	
	protected float timer = 0.0f;

	protected virtual void Update() {
		timer += Time.deltaTime;
	}

    public abstract void Shoot();
}
