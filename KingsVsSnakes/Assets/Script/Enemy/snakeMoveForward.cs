using UnityEngine;
using System.Collections;

public class snakeMoveForward : MonoBehaviour {

//	Animation anim;
	public Rigidbody2D body;
	public float speed;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
//		anim.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		body.AddForce(Vector3.right * speed);
	}
}
