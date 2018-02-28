using UnityEngine;
using System.Collections;

public class SnakeEnemy : MonoBehaviour {

	//enemy variables
	private Vector3 player;
	private Vector2 playerDirection;
	private float xDif;
	private float iDif;
	private Rigidbody2D body;
	//speed of game object
	public float speed = 10f;

	// Use this for initialization
	void Start () {

		//aquiring gameObject Rigidbody2D
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//finding the player gameObject transform.position
		player = GameObject.Find ("Character TD").transform.position;

		//finding the difference in the player's current x and y axis
		xDif = player.x - transform.position.x;
		iDif = player.y - transform.position.y;

		//making the enemy move towards the player using the difference
		playerDirection = new Vector2 (xDif, iDif);

		//applying force to the enemy gameObject
		body.AddForce (playerDirection.normalized * speed);

		speed = speed + 0.01f;
	}
}
