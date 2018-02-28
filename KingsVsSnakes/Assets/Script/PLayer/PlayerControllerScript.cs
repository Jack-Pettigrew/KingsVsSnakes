using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	public Rigidbody2D Body;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	//health variables
	public int startingHealth = 100;
	public int currentHealth;

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
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

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
		if (grounded && Input.GetKeyDown(KeyCode.Space)) 
		{
			anim.SetBool ("Ground", false);
			Body.AddForce (new Vector2 (0, jumpForce));
		}
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

//	void OnCollisionEnter2D(Collider collision)
//	{
//		if (collision.gameObject.layer == "Ramp") {
//			Physics2D.IgnoreCollision ();
//		}
//	}
}