using UnityEngine;
using System.Collections;

public class TopDownMove1 : MonoBehaviour {

	public float speed;

	//spawn

	public GameObject enemy;

	public GameObject level;
	public GameObject run;

	//health variables
	public int startingHealth = 100;
	public int currentHealth;

	//counter public
	public int clickCount = 5;

	//referencing this TopDownMove Script
	TopDownMove topDown;
	bool isDead;
	bool damaged;

	//grabbing onClickDestroy script
	onClickDestroy onclick;

	//level finished bool
	private bool complete = true;

	//holds the sound file
	public AudioClip sound;
	public AudioClip hurt;
	//accesses the AudioSource component
	AudioSource mySound;

	void Awake () {
		mySound = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
	}

	// Update is called once per frame
	void Update()
	{
		//when counter becomes 5...
		if (onClickDestroy.counter >= clickCount){
			//...do this

			//if bool complete is true...
			if (complete) {
				//...do this
				onClickDestroy.counter = 0;
				complete = false;
				currentHealth = 1000;
				//displays level card and animation
				Instantiate (level, new Vector2 (0f, 0f), Quaternion.identity);
				Invoke ("Run", 1.5f);
				Invoke ("Voice", 1.5f);
			}
	
			//changes level after 3 seconds
			Invoke ("ChangeLevel", 2.0f);

		}
	}

	void FixedUpdate () {

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector2.right * speed);
		}

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector2.up * speed);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector2.down * speed);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector2.left * speed);
		}

		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel ("Main Menu");
		}

		if (currentHealth <= 0)
			Application.LoadLevel ("GameOver");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Snake")) 
		{
			//reduces health if hit by an enemy
			currentHealth -= 20;
			Hurt ();
			other.gameObject.SetActive (false);
		}
	}

	void ChangeLevel()
	{
		Application.LoadLevel ("Level5");
	}

	void Run()
	{
		Instantiate (run, new Vector2 (0.0587399f, -3.396728f), Quaternion.identity);
	}

	void Voice () {
		//plays sound effects once
		mySound.PlayOneShot (sound, 1.0f);
	}

	void Hurt() {
		mySound.PlayOneShot (hurt, 1.0f);
	}

}


	



