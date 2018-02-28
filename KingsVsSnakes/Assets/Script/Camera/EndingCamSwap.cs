using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndingCamSwap : MonoBehaviour {

	public GameObject mainCam;
	public GameObject panCam;
	public GameObject topWall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("dsblMain", 5);
		Invoke ("removeWall", 5);
		Invoke ("enblPan", 5);
		Invoke ("changeLvl", 15);
	}

	void dsblMain () {
		mainCam.SetActive (false);
	}

	void enblPan () {
		panCam.SetActive (true);
	}

	void removeWall () {
		topWall.SetActive (false);
	}

	void changeLvl () {
		SceneManager.LoadScene ("Main Menu");
	}
}
