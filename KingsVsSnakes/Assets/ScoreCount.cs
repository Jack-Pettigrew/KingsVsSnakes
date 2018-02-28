using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCount : MonoBehaviour {

	public Text countText;

	public int count;

	// Use this for initialization
	void Start () {
		SetCountText ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString();
	}
}
