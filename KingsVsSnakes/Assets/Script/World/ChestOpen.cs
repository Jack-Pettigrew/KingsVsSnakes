using UnityEngine;
using System.Collections;

public class ChestOpen : MonoBehaviour {

	//variables
	SpriteRenderer renderer;
	public Sprite Open;
	public Sprite Closed;
	public GameObject baby;
	public GameObject particle;
	public GameObject level1;
	public GameObject click;

	//holds the sound file
	public AudioClip sound;
	//accesses the AudioSource component
	AudioSource mySound;

	void Awake () {
		mySound = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		//get comopnent for sprite renderer
		renderer = GetComponent<SpriteRenderer>();

		//disable particles before touch
		particle.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other) {
		//change chest sprite to open
		renderer.sprite = Open;

		//spawn a baby at location stated
		Instantiate (baby, new Vector2 (7.19f, 1.0f), Quaternion.identity);
		
		//aquires the gameobject and the script 'PLayerControllerScript' associated with 'character'
		GameObject character = GameObject.Find ("Character");
		PlayerControllerScript playerControllerScript = character.GetComponent<PlayerControllerScript>();

		//stop the player from moving using the function in 'void start()'
		playerControllerScript.maxSpeed = 0f;
		playerControllerScript.jumpForce = 0f;

		//enabling particle effects on touch
		particle.SetActive (true);

		//if player touches chest, execute 'ChangeLevel' after 3 seconds
		if (other.gameObject.tag == "Player") {
			Invoke("levelOne", 2.0f);
			Invoke ("Voice", 3.5f);
			Invoke("Click", 3.5f);
			Invoke ("ChangeLevel", 4.0f);
		}
	}

	//the change level function
	void ChangeLevel() {
		Application.LoadLevel ("Level1");
	}

	void levelOne () 
	{
		Instantiate (level1, new Vector2 (0f, 0f), Quaternion.identity);
	}

	void Click() 
	{
		Instantiate (click, new Vector2 (0f, -2.02f), Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void Voice () {
		//plays sound effects once
		mySound.PlayOneShot (sound, 1.0f);
	}
}
