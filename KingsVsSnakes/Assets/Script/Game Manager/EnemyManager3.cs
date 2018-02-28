using UnityEngine;
using System.Collections;

public class EnemyManager3 : MonoBehaviour {

	public playerControlBossBattle playerBattle;
	onClickDestroy onClick;
	public GameObject enemy;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Awake () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
		if (playerBattle.currentHealth <= 0f) 
		{
			return;
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}
