using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KingSnake : MonoBehaviour {

	public GameObject player;
	public GameObject EnemyManager;
	public float playerDistance;

	public int KingHealth = 100;
	public int kingCurrentHealth;

	public bool hitLimit = true;

	//holds the sound file
	public AudioClip sound;
	//accesses the AudioSource component
	AudioSource mySound;

	void Awake() {
		player = GameObject.Find ("Character TD");
		kingCurrentHealth = KingHealth;
		mySound = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerDistance = Vector3.Distance (transform.transform.position, player.transform.position);

		if(hitLimit) {
			if(playerDistance <= 5f) {
				Voice ();
				kingCurrentHealth -= 10;
				hitLimit = false;
			}
		}

		if (playerDistance >= 7f) {
			hitLimit = true;
		}

		if (kingCurrentHealth <= 0) {
			SceneManager.LoadScene ("Win");
		}
	}

	void FixedUpdate() {

	}

	void Voice () {
		//plays sound effects once
		mySound.PlayOneShot (sound, 1.0f);
	}
}
