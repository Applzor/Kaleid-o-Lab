using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemyType;
	public float rate;
	private float lastSpawn;
	private float fRate;
	private float maxRate;
	
	void Start () {
		fRate = Random.Range(rate, rate*5);
		maxRate = rate;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastSpawn + fRate) {
			lastSpawn = Time.time;
			fRate = Random.Range(rate, rate*5);
			Instantiate(enemyType, transform.position, transform.rotation);
			rate-=(rate/10);
			rate = Mathf.Clamp(rate, 1.0f, maxRate);
		}
	}
}
