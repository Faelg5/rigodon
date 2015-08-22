using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class CheckKeysPressed : MonoBehaviour {

    enum Direction { };

    private const int LVL1 = 3;
    private const int LVL2 = 7;
    private const int LVL3 = 15;
    private const int LVL4 = 30;
    private const int LVL5 = 60;
    private const int LVL6 = 75;
    private const int LVL7 = 95;
    private const int WIN = 100;

    private const float TRANSITIONTIME = 1.0f;

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

	public int countKeys;

	AudioSource correctAudio;
	AudioSource wrongAudio;

	SpriteRenderer renderer;


	// Use this for initialization
	void Start () {

		difficulty = 0.05f;

		violonSlider = GameObject.FindGameObjectWithTag("ViolonSlider");

		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

		renderer = gameObject.GetComponent<SpriteRenderer>();

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

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag.Contains ("Arrow")){
			countKeys = 1;
		}
	}


	//while note is in the box, check which key is pressed
	void OnTriggerStay2D(Collider2D coll){
		
		// Black note + down = good

		Debug.Log("countKeys" + countKeys);
//		Debug.Log("coll.gameobject.tag==" + coll.gameObject.tag);


		if (countKeys > 0) {
			if (Input.GetKeyUp (KeyCode.DownArrow) && coll.gameObject.tag == "ArrowDown") {

				enemy.GetComponent<MovePosition> ().speedFactor = enemySpeedFactor - difficulty;

				violonSlider.GetComponent<Slider> ().value += 5;

				correctAudio.clip = correctClip;
				correctAudio.Play ();
				countKeys = countKeys - 1;


				renderer.color = new Color (0f, 1f, 0f, 1f); // Set to opaque green

			} else if (Input.GetKeyUp (KeyCode.DownArrow) && coll.gameObject.tag != "ArrowDown") {
				enemy.GetComponent<MovePosition> ().speedFactor = enemySpeedFactor + difficulty;

				violonSlider.GetComponent<Slider> ().value -= 5;

				
				wrongAudio.clip = wrongClip;
				wrongAudio.Play ();
				countKeys = countKeys - 1;


				renderer.color = new Color (1f, 0f, 0f, 1f); // Set to opaque red



			} else if (Input.GetKeyUp (KeyCode.UpArrow) && coll.gameObject.tag == "ArrowUp") {
				enemy.GetComponent<MovePosition> ().speedFactor = enemySpeedFactor - difficulty;

				violonSlider.GetComponent<Slider> ().value += 5;

				
				correctAudio.clip = correctClip;
				correctAudio.Play ();
				countKeys = countKeys - 1;

				renderer.color = new Color (0f, 1f, 0f, 1f); // Set to opaque green



			} else if (Input.GetKeyUp (KeyCode.UpArrow) && coll.gameObject.tag != "ArrowUp") {
				enemy.GetComponent<MovePosition> ().speedFactor = enemySpeedFactor + difficulty;

				violonSlider.GetComponent<Slider> ().value -= 5;

						
				wrongAudio.clip = wrongClip;
				wrongAudio.Play ();
				countKeys = countKeys - 1;

				renderer.color = new Color (1f, 0f, 0f, 1f); // Set to opaque red

			} else if (Input.GetKeyUp (KeyCode.LeftArrow) && coll.gameObject.tag == "ArrowLeft") {
				enemy.GetComponent<MovePosition> ().speedFactor = enemySpeedFactor - difficulty;
				
				violonSlider.GetComponent<Slider> ().value += 5;
				
				
				correctAudio.clip = correctClip;
				correctAudio.Play ();
				countKeys = countKeys - 1;
				
				renderer.color = new Color (0f, 1f, 0f, 1f); // Set to opaque green
				
				
				
			} else if (Input.GetKeyUp (KeyCode.LeftArrow) && coll.gameObject.tag != "ArrowLeft") {
				enemy.GetComponent<MovePosition> ().speedFactor = enemySpeedFactor + difficulty;
				
				violonSlider.GetComponent<Slider> ().value -= 5;
				
				
				wrongAudio.clip = wrongClip;
				wrongAudio.Play ();
				countKeys = countKeys - 1;
				
				renderer.color = new Color (1f, 0f, 0f, 1f); // Set to opaque red
			} else if (Input.GetKeyUp (KeyCode.RightArrow) && coll.gameObject.tag == "ArrowRight") {
				enemy.GetComponent<MovePosition> ().speedFactor = enemySpeedFactor - difficulty;
				
				violonSlider.GetComponent<Slider> ().value += 5;
				
				
				correctAudio.clip = correctClip;
				correctAudio.Play ();
				countKeys = countKeys - 1;
				
				renderer.color = new Color (0f, 1f, 0f, 1f); // Set to opaque green
				
				
				
			} else if (Input.GetKeyUp (KeyCode.RightArrow) && coll.gameObject.tag != "ArrowRight") {
				enemy.GetComponent<MovePosition> ().speedFactor = enemySpeedFactor + difficulty;
				
				violonSlider.GetComponent<Slider> ().value -= 5;
				
				
				wrongAudio.clip = wrongClip;
				wrongAudio.Play ();
				countKeys = countKeys - 1;
				
				renderer.color = new Color (1f, 0f, 0f, 1f); // Set to opaque red
			}







			else {
				renderer.color = new Color (1f, 0f, 0f, 1f); // Set to opaque red
			}
		}
		
		// play happy loop 1 if score > 20 and noteCount is multiple of 4
//		if (violonSlider.GetComponent<Slider>().value > 20 && noteCount%8==0){


	}

	void ChangeLoops(){
		
		
		if (violonSlider.GetComponent<Slider>().value > LVL1){
            Intro.TransitionTo(TRANSITIONTIME);
		}
		if (violonSlider.GetComponent<Slider>().value > LVL2){
            HurdyGurdy.TransitionTo(TRANSITIONTIME);
		}
		if (violonSlider.GetComponent<Slider>().value > LVL3){
            Bagpipes.TransitionTo(TRANSITIONTIME);
		}
		if (violonSlider.GetComponent<Slider>().value > LVL4){
            Lead.TransitionTo(TRANSITIONTIME);
		}
		if (violonSlider.GetComponent<Slider>().value > LVL5){
            Lute.TransitionTo(TRANSITIONTIME);
		}
		if (violonSlider.GetComponent<Slider>().value > LVL6){
            Clavecin.TransitionTo(TRANSITIONTIME);
		}
		if (violonSlider.GetComponent<Slider>().value >= WIN){
            Intro.TransitionTo(TRANSITIONTIME);
			Debug.Log("JOLI RIGODON");
			
			Application.LoadLevel("LevelCompleted");		
        }
	}

}
