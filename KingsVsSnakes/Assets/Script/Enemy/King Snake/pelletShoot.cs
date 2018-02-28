using UnityEngine;
using System.Collections;

public class pelletShoot : MonoBehaviour {

	public float degreesPerSec = 360f;

	public GameObject shotPrefab;
	//public float timeDelay = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//rotate the pellet spawner
		float rotAmount = degreesPerSec * Time.deltaTime;
		float curRot = transform.localRotation.eulerAngles.z;
		transform.localRotation = Quaternion.Euler(new Vector3(0,0,curRot+rotAmount));

		//shoot pellet
		shoot ();

		}

	void shoot () {
		GameObject x = Instantiate(shotPrefab);
		Rigidbody2D rbNew = x.GetComponent<Rigidbody2D> ();
		Rigidbody2D rbThis = GetComponent<Rigidbody2D> ();
		rbNew.velocity = new Vector2 (0, 50);
		rbNew.position = rbThis.position;
		x.transform.position = gameObject.transform.position;
	}
}
