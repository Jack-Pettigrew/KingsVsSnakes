using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour {

	//attack variables
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 25;

	//reference to the GameObject player
	GameObject player;
//	PlayerHealth playerHealth;
	//playerInRange true/false attack when close enough to player
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
//		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	void onTriggerEnter2D (Collider2D other) 
	{
		//if the collider is entering the player
		if(other.gameObject == player)
		{
			playerInRange = true;
		}

//		playerHealth.currentHealth -= 10;
	}

	void OnTriggerExit2D (Collider2D other)
	{
		//if the exiting collider is the player
		if (other.gameObject == player) 
		{
			playerInRange = false;
		}
			
	}

	// Update is called once per frame
	void Update () {
		//add the time since update was last called to the timer
		timer += Time.deltaTime;

		//if the timer exceeds the time between attacks, the player is in range and this enemy is alive
		if (timer >= timeBetweenAttacks && playerInRange) 
		{
			Attack ();
		}
	}

	void Attack()
	{
		//reset the timer
		timer = 0f;

		//if the player has health to lose...
//		if(playerHealth.currentHealth > 0) 
//		{
//			//...damage the player
//			playerHealth.TakeDamage(attackDamage);
//		}
	}
}
