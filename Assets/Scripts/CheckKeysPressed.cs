using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class CheckKeysPressed : MonoBehaviour {


	public GameObject enemy;
	public float enemySpeedFactor;

	public float difficulty;

	public GameObject mainCamera;
	public int noteCount;
	
	public GameObject violonSlider;

	public AudioMixerSnapshot happyLoop1On;
	public AudioMixerSnapshot happyLoop1Off;



	// Use this for initialization
	void Start () {

		difficulty = 0.05f;

		violonSlider = GameObject.FindGameObjectWithTag("ViolonSlider");

		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		enemySpeedFactor = enemy.GetComponent<MovePosition>().speedFactor;

		noteCount = mainCamera.GetComponent<AnalyzeSong> ().noteCount;


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
		
		// play happy loop 1 if score > 20 and noteCount is multiple of 4
		if (violonSlider.GetComponent<Slider>().value > 20 && noteCount%8==0){
			happyLoop1On.TransitionTo(0.1f);			
		} else if (violonSlider.GetComponent<Slider>().value < 16 && noteCount%8==0){
			happyLoop1Off.TransitionTo(0.1f);			
		}
	}
}
