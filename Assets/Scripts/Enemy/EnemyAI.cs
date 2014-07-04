using UnityEngine;
using System.Collections;

public abstract class EnemyAI : MonoBehaviour {

    //  Stats
	public float healthMax;
	protected float healthCurrent;
    public int score;

    //  Effects
	public GameObject[] explodeParticles;
    public GameObject[] explodeSounds;
    public GameObject[] moveParticles;

    //  Navigation
    protected Transform target;
    protected NavMeshAgent navAgent;

    //  Misc
	protected GameObject gameManager;

    protected void Start()
    {
        gameManager = GameObject.Find("$GameManager");
    }

    protected void Awake()
    {
		healthCurrent = healthMax;

        //  Setup Navigation
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find(Tags.Player).transform;
	}

    protected void FixedUpdate()
    {
        //  Make sure the Enemy is targeting the players current position
        navAgent.SetDestination(target.position);

        //  Move the Player
        Move();

        //  Check for player death
        if (healthCurrent <= 0) Die();
	}

    protected virtual void Move() { }
    protected virtual void OnDeath() { }

    protected virtual void Die() {
        //  Increase Score
        gameManager.transform.GetComponent<GameManager>().playerScore += score;

        OnDeath();

        //  Explode the Character
        Explode();

        //  Destroy the Object
        Destroy(this.gameObject);
    }

    protected void Explode()
    {
		//	Create Particle Emitter
        if (explodeParticles.Length > 0)
            foreach(GameObject particle in explodeParticles)
                Instantiate(particle, transform.position, Quaternion.Euler(-90, 0, transform.rotation.eulerAngles.z));
		
		//	Play sound effect
        if (explodeSounds.Length > 0)
            foreach (GameObject sound in explodeSounds)
                Instantiate(sound, transform.position, transform.rotation);
	}

    //!----PUBLIC METHODS----!
    public virtual void TakeDamage(float damage)
    {
		healthCurrent -= damage;
	}
}
