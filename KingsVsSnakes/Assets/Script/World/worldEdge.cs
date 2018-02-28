using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class worldEdge : MonoBehaviour {

	PlayerControllerScript player;

	// Use this for initialization
	void Start () {
	
	}

	//when player touches collider...
	void onTriggerEnter2D (Collider2D other) {
		//...end level
		if (other.gameObject.CompareTag ("Player"))
			player.currentHealth -= 100;
		
		if (other.gameObject.tag == "Baby") {
			GameObject character = GameObject.Find ("Character");
			ThrowPlayerController throwplayerController = character.GetComponent<ThrowPlayerController> ();
			throwplayerController.currentHealth -= 100;

		}
	}
}