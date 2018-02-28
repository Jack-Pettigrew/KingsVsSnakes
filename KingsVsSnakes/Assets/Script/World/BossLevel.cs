using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossLevel : MonoBehaviour {

	//audio variables
	//holds the sound file
	public AudioClip riser;
	public AudioClip sound;
	//accesses the AudioSource component
	AudioSource mySound;

	//variables GameObjects
	public GameObject baby;
	public GameObject snake;
	public GameObject levelcard;
	public GameObject subtitle;
	public GameObject mainCamStill;
	public GameObject mainCanAni;

	public bool playAni = false;

	void Awake() {
		//gets the component at program loading
		mySound = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Baby")) {
			//disable baby and enable snake
			baby.SetActive (false);
			snake.SetActive (true);
			mainCamStill.SetActive (false);
			mainCanAni.SetActive (true);

			//get player character and set speed to 0 float
			GameObject character = GameObject.Find ("Character");
			ThrowPlayerController throwplayerController = character.GetComponent<ThrowPlayerController> ();
			throwplayerController.maxSpeed = 0f;

			//plays sound effects once
			mySound.PlayOneShot (riser, 1.0f);
			playAni = true;

			//display level card + instruction
			Invoke("ReActivate", 15f);
			Invoke ("Disable", 15f);
			Invoke("LevelCard", 15f);
			Invoke ("Voice", 16.5f);
			Invoke ("Subtitle", 16.5f);
			Invoke ("ChangeLevel", 18f);
		}
	}
		
	void ChangeLevel(){
		SceneManager.LoadScene ("BossBattle");
	}

	void LevelCard(){
		Instantiate (levelcard, new Vector2 (0f, -0.03f), Quaternion.identity);
	}

	void Subtitle (){
		Instantiate (subtitle, new Vector2 (0f, -2.02f), Quaternion.identity);
	}

	void ReActivate (){
		mainCamStill.SetActive (true);
	}

	void Disable(){
		mainCanAni.SetActive (false);
	}

	void Voice () {
		//plays sound effects once
		mySound.PlayOneShot (sound, 1.0f);
	}
}
