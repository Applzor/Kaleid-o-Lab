using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Railgun : Weapon
{
	//	Prefabs
	public GameObject bulletPrefab;

	//	Weapon Attachments
	public GameObject[] attachments = null;
	protected int attachment = 0;

	//	Particles
	public GameObject[] shellEmitter;
	public GameObject[] effectEmitter;

    new void Start()
    {
        base.Start();
        damage = GameParameters.Instance.RailgunDamage;
        firerate = GameParameters.Instance.RailgunFireRate;
    }

	public override void Shoot(float fire)
    {
		if (fire == 1 && cooldown <= 0)
		{
			animationController.SetTrigger("Fire");

			ShootRailAlt(attachment);

			//	Play particles
			int shell = Mathf.Min(attachment, shellEmitter.Length);
			if (shellEmitter.Length > 0) shellEmitter[shell].particleSystem.Play();
			int effect = Mathf.Min(attachment, effectEmitter.Length);
			if (effectEmitter.Length > 0) effectEmitter[effect].particleSystem.Play();

			//	Reset Timer
            cooldown = firerate;
			CycleAttachment();
		}
	}

	//	Raycasts and damages all enemies in a line
	void ShootRail(int i)
	{
		if (attachments.Length == 0)
		{
			Debug.LogError("Railgun: No attachments attached.");
			return;
		}

		Vector3 position = attachments[i].transform.position;
		Vector3 direction = attachments[i].transform.forward;

		//	We need the last object so we can move our trail renderer object there
		Vector3 lastHitPosition = Vector3.zero;

		//	All objects hit
		List<RaycastHit> hits = new List<RaycastHit>(Physics.RaycastAll(position, direction));
		hits.Sort(RaycastHit_SortAscending);
		foreach (RaycastHit hit in hits)
		{
			lastHitPosition = hit.point;

			//@IMPRV
			//	Damage the object if enemy
			if (hit.collider.tag == Tags.Enemy)
				hit.collider.GetComponent<EnemyAI>().TakeDamage(damage);
			else
				break;
		}

		GameObject rail = Instantiate(bulletPrefab, position, transform.rotation) as GameObject;
		LineRenderer line = rail.GetComponent<LineRenderer>();
		line.SetPosition(0, position);
		line.SetPosition(1, lastHitPosition);
	}
	void ShootRailAlt(int i)
	{
		if (attachments.Length == 0)
		{
			Debug.LogError("Railgun: No attachments.");
			return;
		}

		Vector3 position = attachments[i].transform.position;
		Vector3 direction = attachments[i].transform.forward;

		//	We need the last object so we can move our trail renderer object there
		float lastHitDistance = 0f;

		//	All objects hit
		List<RaycastHit> hits = new List<RaycastHit>(Physics.RaycastAll(position, direction));
		hits.Sort(RaycastHit_SortAscending);
		foreach (RaycastHit hit in hits)
		{
			lastHitDistance = hit.distance;
			if (hit.collider.tag != Tags.Enemy && hit.collider.isTrigger == false)
				break;
		}

		GameObject rail = Instantiate(bulletPrefab, position + direction * (lastHitDistance*0.5f), transform.rotation) as GameObject;
		rail.GetComponent<Bullets>().Damage = damage;
		rail.transform.localScale = new Vector3(rail.transform.localScale.x, rail.transform.localScale.y, lastHitDistance);

		LineRenderer line = rail.GetComponent<LineRenderer>();
		line.SetPosition(0, new Vector3(0, 0,-.5f));
		line.SetPosition(1, new Vector3(0, 0, .5f));
	}

	//	Iterates through each attachment index at a time with wrapping
	void CycleAttachment()
	{
		animationController.SetInteger("Attachment", attachment);
		attachment = (attachment + 1 >= attachments.Length) ? 0 : attachment + 1;
	}

	private static int RaycastHit_SortAscending(RaycastHit A, RaycastHit B)
	{
		if (A.distance == B.distance)
			return 0;
		else if (A.distance > B.distance)
			return 1;
		return -1;
	}
}
