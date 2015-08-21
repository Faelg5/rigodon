using UnityEngine;
using System.Collections;

public class PlayEricSounds : MonoBehaviour {

	Transform transform;

	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
	public AudioClip clip4;
	public AudioClip clip5;
	public AudioClip clip6;
	public AudioClip clip7;

	AudioSource audio1;
	AudioSource audio2;
	AudioSource audio3;
	AudioSource audio4;
	AudioSource audio5;
	AudioSource audio6;
	AudioSource audio7;


	int a, b, c, d, e, f, g;

		
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
		a = b = c = d = e = f = g = 1;
	}

	void Awake(){
		audio1 = GetComponent <AudioSource> ();
		audio2 = GetComponent <AudioSource> ();
		audio3 = GetComponent <AudioSource> ();
		audio4 = GetComponent <AudioSource> ();
		audio5 = GetComponent <AudioSource> ();
		audio6 = GetComponent <AudioSource> ();
		audio7 = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 2.5f && a == 1) {
			audio1.clip = clip1;
			audio1.Play ();
			a -= 1;
		} else if (transform.position.x > 3.5 && b == 1) {
			audio2.clip = clip2;
			audio2.Play ();
			b -= 1;

		} else if (transform.position.x > 4.5 && c == 1) {
			audio3.clip = clip3;
			audio3.Play ();
			c -= 1;

		} else if (transform.position.x > 5.5 && d == 1) {
			audio4.clip = clip4;
			audio4.Play ();
			d -= 1;

		} else if (transform.position.x > 6.0 && e == 1) {
			audio5.clip = clip5;
			audio5.Play ();
			e -= 1;

		} else if (transform.position.x > 6.5 && f == 1) {
			audio6.clip = clip6;
			audio6.Play ();
			f -= 1;

		} else if (transform.position.x > 6.0 && g == 1) {
			audio7.clip = clip7;
			audio7.Play ();
		}
	}
}
