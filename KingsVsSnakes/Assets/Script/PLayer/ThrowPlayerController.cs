using UnityEngine;
using System.Collections;

public class ThrowPlayerController : MonoBehaviour {

	//movement variables
	public float maxSpeed = 10f;
	bool facingRight = true;
	public Rigidbody2D Body;

	//animation variables
	Animator anim;

	//health variables
	public int startingHealth = 100;
	public int currentHealth;

	//=====================================================

	// Use this for initialization
	void Start () 
	{
		Body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		//starting health
		currentHealth = startingHealth;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		anim.SetFloat ("vSpeed", Body.velocity.y);

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs(move));
			
		Body.velocity = new Vector2 (move * maxSpeed, Body.velocity.y);

		if (Input.GetKey(KeyCode.Escape))
			Application.Quit();

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		//Health die result
		if (currentHealth <= 0)
			Application.LoadLevel ("GameOver");	
	}
		
	void Update ()
	{

	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	//on touch method
	void OnTriggerEnter2D(Collider2D other)
	{
		//if snake touches player...
		if (other.gameObject.CompareTag ("Snake")) 
		{
			//...reduces health if hit by an enemy
			currentHealth -= 100;
		}

		if (other.gameObject.CompareTag ("worldEdge")) 
		{
			currentHealth -= 100;
		}
	}
}