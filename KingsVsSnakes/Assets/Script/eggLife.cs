using UnityEngine;
using System.Collections;

public class eggLife : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("eggDelete", 10f);
	}

	void eggDelete() {
		Destroy (gameObject);
	}
}
