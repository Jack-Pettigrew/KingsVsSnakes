using UnityEngine;
using System.Collections;

public class EnemyManager1 : MonoBehaviour {

	public TopDownMove1 topDownMove;
	onClickDestroy onClick;
	public GameObject enemy;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	public int spawnLimit = 5;

	// Use this for initialization
	void Awake () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
		if (topDownMove.currentHealth <= 0f || onClickDestroy.counter >= spawnLimit) 
		{
			return;
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}
