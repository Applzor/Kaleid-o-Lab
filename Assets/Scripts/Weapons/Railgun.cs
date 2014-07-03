using UnityEngine;
using System.Collections;

public class Railgun : Weapon
{
	public int attachments = 2;
	protected int attachment = 0;

	public override void Shoot(float fire)
    {
		if (fire <= 0)
			return;

		if (cooldown <= 0)
		{
			animationController.SetTrigger("Fire");

			//	Play particles
			int bullet = Mathf.Min(attachment, bulletEmitter.Length);
			if (bulletEmitter.Length > 0) bulletEmitter[bullet].particleSystem.Play();

			int shell = Mathf.Min(attachment, shellEmitter.Length);
			if (shellEmitter.Length > 0) shellEmitter[shell].particleSystem.Play();

			int effect = Mathf.Min(attachment, effectEmitter.Length);
			if (effectEmitter.Length > 0) effectEmitter[effect].particleSystem.Play();

			//	Reset Timer
			cooldown = rate;
			CycleAttachment();
		}
	}

	//	Iterates through each attachment index at a time with wrapping
	void CycleAttachment()
	{
		animationController.SetInteger("Attachment", attachment);
		attachment = (attachment + 1 >= bulletEmitter.Length) ? 0 : attachment + 1;
	}
}
