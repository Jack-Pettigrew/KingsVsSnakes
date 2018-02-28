using UnityEngine;
using System.Collections;

public class throwBaby : MonoBehaviour {

	Rigidbody2D body;
	//followPlayerBaby fpb;
	public GameObject baby;
	public float xAxis;
	public float yAxis;
	public float gravity;

	private bool thrown = false;

	ThrowPlayerController throwplayer;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log ("Works");
			baby.GetComponent<followPlayerBaby>().enabled = false;
			thrown = true;
		}

		if (thrown) {
			//transform.Rotate (new Vector3 (0, 0, -15));
			transform.Translate (new Vector2 (xAxis, yAxis));
			if (baby.transform.position.y >= -0.05)
				yAxis = yAxis - gravity;
			if (baby.transform.position.y <= -4.3)
				xAxis = 0f;
		}
	}
}
