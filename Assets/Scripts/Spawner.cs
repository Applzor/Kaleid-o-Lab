using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] objectsToSpawn;
	public float spawnRate;
	protected float spawnTimer;

	void Update() {
		spawnTimer += Time.deltaTime;


		if (spawnTimer >= spawnRate) {
			spawnTimer -= spawnRate;
			foreach (GameObject obj in objectsToSpawn) {
				Instantiate(obj, transform.position, transform.rotation);
			}
		}

	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (transform.position, transform.localScale);
	}
}
