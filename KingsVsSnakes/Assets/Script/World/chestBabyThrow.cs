using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class chestBabyThrow : MonoBehaviour {

	public GameObject levelcard;
	public GameObject subtitle;
	public GameObject baby;

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
	void FixedUpdate () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Baby") {
			Debug.Log("Triggered");

			baby.SetActive (false);
			
			GameObject character = GameObject.Find ("Character");
			ThrowPlayerController throwplayerController = character.GetComponent<ThrowPlayerController> ();
			throwplayerController.maxSpeed = 0f;

			GameObject snake = GameObject.Find ("Snake_Chase");
			snake.SetActive (false);

			//display level 3 card + instruction
			Instantiate (levelcard, new Vector2 (0f, -0.03f), Quaternion.identity);
			Invoke ("Subtitle", 1.5f);
			Invoke ("Voice", 1.5f);
			Invoke ("nextLevel", 2.0f);
		}
	}

	void Subtitle() {
		Instantiate (subtitle, new Vector2 (0f, -2.02f), Quaternion.identity);
	}

	void nextLevel() {
		SceneManager.LoadScene ("Level4");
	}

	void Voice () {
		//plays sound effects once
		mySound.PlayOneShot (sound, 1.0f);
	}
}
