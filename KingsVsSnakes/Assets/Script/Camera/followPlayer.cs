using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	//variable for the player's current postion
	public Transform player;

	//variable for the camera follow offset
	public Vector3 offSet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//camera will follow player in accordance to the offset
		transform.position = new Vector3 (player.position.x + offSet.x, 1.8f, offSet.z);
	}
}
