using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelArrow1 : MonoBehaviour {

	public GameObject levelcard;
	public GameObject levelthrow;

	//holds the sound file
	public AudioClip sound;
	//accesses the AudioSource component
	AudioSource mySound;

	void Awake () {
		mySound = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == ("Player")) {
			
			//grabbing Player Controls...
			GameObject character = GameObject.Find("Character");
			PlayerControllerScript playerControllerScript = character.GetComponent<PlayerControllerScript> ();
			//...to stop movement
			playerControllerScript.maxSpeed = 0f;
			playerControllerScript.jumpForce = 0f;

			//grabbing snake controller...
			GameObject snake = GameObject.Find ("Snake_Chase");
			snakeChase snakeC = snake.GetComponent<snakeChase> ();
			//...to stop chase
			snakeC.speed = 0f;

			//display level 3 card + instruction
			Instantiate (levelcard, new Vector2 (137f, 1.64f), Quaternion.identity);
			Invoke ("levelThrow", 1.5f);
			Invoke ("Voice", 1.5f);
			Invoke ("loadLevel", 2.0f);
		}
	}

	void loadLevel (){
		SceneManager.LoadScene ("Level6");
	}

	void levelThrow () 
	{
		Instantiate (levelthrow, new Vector2 (137.2f, -1.28f), Quaternion.identity);
	}

	void Voice () {
		//plays sound effects once
		mySound.PlayOneShot (sound, 1.0f);
	}
}
