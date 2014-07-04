using UnityEngine;
using System.Collections;

public class SlimeAI : EnemyAI {

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

    new void Awake()
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

        for (int i = 0; i < moveParticles.Length; i++)
            Instantiate(moveParticles[i], transform.position, transform.rotation);
    }

    protected override void OnDeath()
    {
        Split();
    }

    void Split()
    {
        //  Half the size of the slime
        float halfScale = transform.localScale.x / 2.0f;
        if (halfScale < 1) return;

        //  Only ever spawn two slimes
        for (int i = 0; i < spawnAmount; i++)
        {   
            //  Spawn the slimes in opposite directions
            Vector3 direction = Quaternion.AngleAxis(180*i+90, transform.up) * transform.forward;
            direction.Normalize();

            //  Spawn the Slimes at the current Slimes position adjusted apart so they don't collide and on the ground
            GameObject obj = Instantiate(this.gameObject, 
                transform.position + (direction * halfScale) - (transform.up * halfScale * 0.25f), 
                transform.rotation) as GameObject;
            obj.transform.localScale = new Vector3(halfScale, halfScale, halfScale);
        }
    }
}
