using UnityEngine;
using System.Collections;

public class StartMusic : MonoBehaviour {

	bool isStarted;

	// Use this for initialization
	void Start () {
		isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag.Contains("Note") && !isStarted) {
			isStarted = true;
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
		}
	}

}
