using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckKeysPressed : MonoBehaviour {


	public GameObject enemy;
	public float enemySpeedFactor;

	public float difficulty;
	
	public GameObject violonSlider;


	// Use this for initialization
	void Start () {

		difficulty = 0.05f;

		violonSlider = GameObject.FindGameObjectWithTag("ViolonSlider");


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		enemySpeedFactor = enemy.GetComponent<MovePosition>().speedFactor;

	}
	//while note is in the box, check which key is pressed
	void OnTriggerStay2D(Collider2D coll){
		
		// Black note + down = good
		
		if (Input.GetKeyUp ("down") && coll.gameObject.tag == "BlackNote" && enemy.GetComponent<MovePosition>().speedFactor > 0.0f) {

			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor -difficulty;

			violonSlider.GetComponent<Slider>().value += 5;

		} else if(Input.GetKeyUp ("down") && coll.gameObject.tag == "WhiteNote") {
			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor +difficulty;

			violonSlider.GetComponent<Slider>().value -= 5;

		} else if (Input.GetKeyUp ("up") && coll.gameObject.tag == "WhiteNote" && enemy.GetComponent<MovePosition>().speedFactor > 0.0f) {
			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor -difficulty;

			violonSlider.GetComponent<Slider>().value += 5;


		} else if(Input.GetKeyUp ("up") && coll.gameObject.tag == "BlackNote") {
			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor +difficulty;

			violonSlider.GetComponent<Slider>().value -= 5;


		}
	}
}
