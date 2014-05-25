using UnityEngine;
using System.Collections;

public class Railgun_Shoot : _Weapon
{

    public GameObject[] particles;
    public GameObject[] animations;
    protected short attach = 0;

    public override void Shoot()
    {

        if (timer >= cooldown)
        {
            timer = 0.0f;

            //  Shoot the specific Weapon
            //particles[attach].particleSystem.Play();
            animations[attach].animation.Play();
            DamageLine(animations[attach].transform);

            //  Cycle attachments
            attach++;
            if (attach > animations.Length - 1)
                attach = 0;
        }
    }

    void DamageLine(Transform obj) {
        //  Don't use raycast, will only hit the first object it comes across
    }
}
