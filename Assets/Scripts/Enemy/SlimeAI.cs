using UnityEngine;
using System.Collections;

public class SlimeAI : EnemyAI {

    public GameObject spawnEnemy;
    const int spawnAmount = 2;

    protected float moveForce;
    AnimationCurve moveFCurve = AnimationCurve.Linear(1, 100, 5, 250);

    protected float jumpForce;
    AnimationCurve jumpFCurve = AnimationCurve.Linear(1, 150, 5, 150);

    protected float jumpCooldown;
    AnimationCurve jumpCCurve = AnimationCurve.Linear(1, 1.0f, 5, 2.0f);

    protected float jumpLast = 0.0f;
    protected bool grounded = false;
    protected float scale;

    void Awake()
    {
        base.Awake();
        navAgent.updatePosition = false;

        //  Set health and speed based on size
        scale = transform.localScale.x;
        moveForce = moveFCurve.Evaluate(scale);
        jumpForce = jumpFCurve.Evaluate(scale);
        jumpCooldown = jumpCCurve.Evaluate(scale);
    }

    void OnCollisionEnter(Collision obj)
    {
        grounded = true;
    }

    protected override void Move()
    {
        if (!grounded || Time.time < jumpLast + jumpCooldown)
            return;

        grounded = false;
        jumpLast = Time.time;
        Vector3 dir = (navAgent.steeringTarget - transform.position).normalized;
        rigidbody.AddForce(dir * moveForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rigidbody.AddForce(transform.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    protected override void OnDeath()
    {
        Split();
    }

    void Split()
    {
        if (spawnEnemy)
        {
            //  Half the size of the slime
            float halfScale= spawnEnemy.transform.localScale.x / 2.0f;
            if (halfScale < 1) return;

            //  Only ever spawn two slimes
            for (int i = 0; i < spawnAmount; i++)
            {   
                //  Spawn the slimes in opposite directions
                Vector3 direction = Quaternion.AngleAxis(180*i+90, transform.up) * transform.forward;
                direction.Normalize();

                spawnEnemy.transform.localScale = new Vector3(halfScale, halfScale, halfScale);
                GameObject obj = Instantiate(spawnEnemy, transform.position + (direction * halfScale), transform.rotation) as GameObject;
                obj.rigidbody.AddForce(direction * moveForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }
    }
}
