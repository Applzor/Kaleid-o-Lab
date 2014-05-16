using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float healthMax;
	protected float healthCurrent;

	public GameObject[] particles;

	protected GameObject gameManager;

	protected GameObject navTarget;
	protected NavMeshAgent navAgent;

	protected virtual void Awake() {
		healthCurrent = healthMax;
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
	}

    protected virtual void Start()
    {
		gameManager = GameObject.Find ("$GameManager");

        //  NavMesh
		navAgent = GetComponent<NavMeshAgent> ();
		navTarget = GameObject.Find ("Player");
	}

    protected virtual void FixedUpdate()
    {
        //  Make sure the Enemy is targeting the players current position
		navAgent.SetDestination (navTarget.transform.position);
        Move();
	}

    protected virtual void Move()
    {
        if (!navAgent.updatePosition)
            navAgent.updatePosition = true;
    }

    public virtual void Explode()
    {
		//	Create Particle Emitters
		for (int i = 0; i < particles.Length; i++) {
			Instantiate(particles[i], transform.position, Quaternion.Euler(-90,0,transform.rotation.eulerAngles.z));
		}
		
		//	Play sound effect

		//	Add to score?
		gameManager.transform.GetComponent<_GameManager> ().playerScore++;
		
		//	Delete bullet last
		Destroy (this.gameObject);
	}

    public virtual void TakeDamage(float damage)
    {
		healthCurrent -= damage;

        if (healthCurrent <= 0)
            Explode();
	}
}
