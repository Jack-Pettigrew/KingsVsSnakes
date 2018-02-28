using UnityEngine;
using System.Collections;

public class followPlayerBaby : MonoBehaviour {

	private Transform lookAt;
	private Vector3 startOffset;

	public ThrowPlayerController throwplayer;

	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = lookAt.position + startOffset;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("worldEdge")) 
		{
			throwplayer.currentHealth -= 100;
		}
	}
}
