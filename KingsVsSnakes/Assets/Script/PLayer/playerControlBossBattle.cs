using UnityEngine;
using System.Collections;

public class playerControlBossBattle : MonoBehaviour {

	public float speed;

	//spawn
	public GameObject egg;
	//public GameObject pellet;

	//health variables
	public int startingHealth = 100;
	public int currentHealth;

	//referencing this Script
	playerControlBossBattle playerBattle;
	bool isDead;
	bool damaged;

	//level finished bool
	private bool complete = true;

	//holds the sound file
	public AudioClip sound;
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
		//being hit by egg
		if (other.gameObject.tag == "egg") 
		{
			//reduces health if hit by an enemy
			currentHealth -= 12;
			Voice ();
			Destroy(other.gameObject);
		}

		//being hit by pellet
	}

	void ChangeLevel()
	{
		Application.LoadLevel ("Level2");
	}

	void Voice () {
		//plays sound effects once
		mySound.PlayOneShot (sound, 1.0f);
	}
}
