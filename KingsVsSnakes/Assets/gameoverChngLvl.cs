using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameoverChngLvl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape))
			ChangeLevel ();

		Invoke ("ChangeLevel", 10f);
	}

	void ChangeLevel () {
		SceneManager.LoadScene("Main Menu");
	}
}
