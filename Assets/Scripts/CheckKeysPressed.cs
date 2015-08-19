using UnityEngine;
using System.Collections;

public class CheckKeysPressed : MonoBehaviour {


	public GameObject enemy;
	public float enemySpeedFactor;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		enemySpeedFactor = enemy.GetComponent<MovePosition>().speedFactor;
}
	//while note is in the box, check which key is pressed
	void OnTriggerStay2D(Collider2D coll){
		
		// Black note + down = good
		
		if (Input.GetKey ("down") && coll.gameObject.tag == "BlackNote") {

			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor -0.1f;

		} else if(Input.GetKey ("down") && coll.gameObject.tag == "WhiteNote") {
			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor +0.1f;

		} else if (Input.GetKey ("up") && coll.gameObject.tag == "WhiteNote") {
			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor -0.1f;

		} else if(Input.GetKey ("up") && coll.gameObject.tag == "BlackNote") {
			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor +0.1f;

		}
	}
}
