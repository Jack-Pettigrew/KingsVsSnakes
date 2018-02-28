using UnityEngine;
using System.Collections;

public class snakeChase : MonoBehaviour {

	//enemy variables
	private Vector3 player;
	private Vector2 playerDirection;
	private float xDif;
	private Rigidbody2D body;
	//speed of game object
	public float speed;

	// Use this for initialization
	void Start () {

		//aquiring gameObject Rigidbody2D
		body = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		//finding the player gameObject transform.position
		player = GameObject.Find ("Character").transform.position;

		//finding the difference in the player's current x and y axis
		xDif = player.x - transform.position.x;

		//making the enemy move towards the player using the difference
		playerDirection = new Vector2 (xDif, 0);

		//applying force to the enemy gameObject
		body.AddForce (playerDirection.normalized * speed);
		body.velocity = speed * (body.velocity.normalized);

		speed = speed + 0.002f;
	}
}
