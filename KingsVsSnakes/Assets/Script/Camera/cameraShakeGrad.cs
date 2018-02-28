using UnityEngine;
using System.Collections;

public class cameraShakeGrad : MonoBehaviour {

	public float shakeTimer;
	public float shakeAmount;

	// Use this for initialization
	void Start () {
		ShakeCamera (0.1f, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (shakeTimer >= 0) {
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

			shakeTimer -= Time.deltaTime;

		}
	}

	public void ShakeCamera(float shakePwr, float shakeDur)
	{
		shakeAmount = shakePwr;
		shakeTimer = shakeDur;
	}
}
