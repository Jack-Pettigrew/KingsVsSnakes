using UnityEngine;
using System.Collections;

public class onClickDestroy : MonoBehaviour {

	static public int counter = 0;

	//holds the sound file
	public AudioClip sound;
	//accesses the AudioSource component
	AudioSource mySound;

	public bool playsound =false;


	void Awake () {
		mySound = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() 
	{
		playsound = true;
		counter++;
		print (counter);
		Destroy (gameObject);
	}

	void Voice () {
		//plays sound effects once
		mySound.PlayOneShot (sound, 1.0f);
	}
}