using UnityEngine;
using System.Collections;

public class MoveNote : MonoBehaviour {

	public float speedFactor = 1.0f;
	public float moveSpeed = 1.0f;
	//public float speedFactor = 1.0f;

	void FixedUpdate() {

	
		var rb2d = GetComponent<Rigidbody2D> ();
		//hero = GameObject.Find ("hero");

		//add moveSpeed on the vector2's formula
		rb2d.MovePosition (new Vector2 (rb2d.position.x - moveSpeed * speedFactor * Time.fixedDeltaTime, -2) );


		if (transform.position.x < 0.0f) {
			Destroy(gameObject, 0f);

		}
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "NoteBorder") {
//			Debug.Log("Hit Note");


//			AudioSource audio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
//			audio.Play();
		}
	}
}