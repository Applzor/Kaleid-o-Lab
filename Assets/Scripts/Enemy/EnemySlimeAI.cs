using UnityEngine;
using System.Collections;

public class EnemySlimeAI : EnemyAI {

    public float moveForce;
    public float jumpForce;
    public float jumpCooldown;

    private bool grounded = false;
    private float lastJump = 0.0f;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        navAgent.updatePosition = false;
	}

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        grounded = false;
    }

    protected virtual void OnCollisionStay()
    {
        grounded = true;
    }

    protected override void Move()
    {
        Jump();
    }

    void Jump()
    {
        if (!grounded || Time.time < lastJump + jumpCooldown)
            return;

        lastJump = Time.time;
        Vector3 dir = (navAgent.steeringTarget - transform.position).normalized;
        rigidbody.AddForce(dir * moveForce, ForceMode.VelocityChange);
        rigidbody.AddForce(transform.up * jumpForce, ForceMode.Force);
    }

    
}
