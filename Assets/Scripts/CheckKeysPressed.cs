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
	public AudioMixerSnapshot Intro;
	public AudioMixerSnapshot HurdyGurdy;
	public AudioMixerSnapshot Bagpipes;
	public AudioMixerSnapshot Lead;
	public AudioMixerSnapshot Lute;
	public AudioMixerSnapshot Clavecin;

	public AudioClip wrongClip;

	public AudioClip correctClip;

	AudioSource correctAudio;
	AudioSource wrongAudio;


	// Use this for initialization
	void Start () {

		difficulty = 0.05f;

		violonSlider = GameObject.FindGameObjectWithTag("ViolonSlider");

		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");


	}

	void Awake(){
		correctAudio = GetComponent <AudioSource> ();
		wrongAudio = GetComponent <AudioSource> ();
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		enemySpeedFactor = enemy.GetComponent<MovePosition>().speedFactor;

		noteCount = mainCamera.GetComponent<AnalyzeSong> ().noteCount;

		ChangeLoops ();



	}
	//while note is in the box, check which key is pressed
	void OnTriggerStay2D(Collider2D coll){
		
		// Black note + down = good
		
		if (Input.GetKeyUp ("down") && coll.gameObject.tag == "BlackNote" && enemy.GetComponent<MovePosition>().speedFactor > 0.0f) {

			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor -difficulty;

			violonSlider.GetComponent<Slider>().value += 5;

			correctAudio.clip = correctClip;
			correctAudio.Play ();

		} else if(Input.GetKeyUp ("down") && coll.gameObject.tag == "WhiteNote") {
			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor +difficulty;

			violonSlider.GetComponent<Slider>().value -= 5;

			
			wrongAudio.clip = correctClip;
			wrongAudio.Play ();



		} else if (Input.GetKeyUp ("up") && coll.gameObject.tag == "WhiteNote" && enemy.GetComponent<MovePosition>().speedFactor > 0.0f) {
			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor -difficulty;

			violonSlider.GetComponent<Slider>().value += 5;

			
			correctAudio.clip = correctClip;
			correctAudio.Play ();



		} else if(Input.GetKeyUp ("up") && coll.gameObject.tag == "BlackNote") {
			enemy.GetComponent<MovePosition>().speedFactor = enemySpeedFactor +difficulty;

			violonSlider.GetComponent<Slider>().value -= 5;

					
					wrongAudio.clip = correctClip;
					wrongAudio.Play ();
		}
		
		// play happy loop 1 if score > 20 and noteCount is multiple of 4
//		if (violonSlider.GetComponent<Slider>().value > 20 && noteCount%8==0){


	}

	void ChangeLoops(){
		
		
		if (violonSlider.GetComponent<Slider>().value > 5){
			Intro.TransitionTo(1.0f);
		}
		if (violonSlider.GetComponent<Slider>().value > 10){
			HurdyGurdy.TransitionTo(1.0f);
		}
		if (violonSlider.GetComponent<Slider>().value > 20){
			Bagpipes.TransitionTo(1.0f);
		}
		if (violonSlider.GetComponent<Slider>().value > 40){
			Lead.TransitionTo(1.0f);
		}
		if (violonSlider.GetComponent<Slider>().value > 60){
			Lute.TransitionTo(1.0f);
		}
		if (violonSlider.GetComponent<Slider>().value > 85){
			Clavecin.TransitionTo(1.0f);
		}
		if (violonSlider.GetComponent<Slider>().value >99){
			Intro.TransitionTo(1.0f);
			Debug.Log("JOLI RIGODON");
			
			Application.LoadLevel("MainMenu");		
        }
	}

}
