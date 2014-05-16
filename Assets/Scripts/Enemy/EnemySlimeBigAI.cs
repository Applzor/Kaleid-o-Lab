using UnityEngine;
using System.Collections;

public class EnemySlimeBigAI : EnemySlimeAI {

    public GameObject toSpawn;
    public int amount;

	// Use this for initialization
    public override void Explode()
    {
        float angle = 360 / amount;
        float size = (toSpawn.transform.localScale.x + toSpawn.transform.localScale.z) / 2.0f;
        size++;

        for (int i = 0; i < amount; i++)
        {
            Vector3 randDir = Quaternion.AngleAxis(angle * i, transform.up) * transform.forward;
            randDir.Normalize();
            GameObject obj = Instantiate(toSpawn, transform.position + (randDir * size), transform.rotation) as GameObject;
            obj.rigidbody.AddForce(transform.up * Random.Range(-5, 5), ForceMode.Impulse);
        }
        base.Explode();
        Destroy(this.gameObject);
    }

    
}
