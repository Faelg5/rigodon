using UnityEngine;
using System.Collections;

public class AnalyzeSong : MonoBehaviour {

//	[System.Diagnostics.Conditional("DEBUG")]
#if DEBUG
	public GameObject cube01;
//	public GameObject cube02;
//	public GameObject cube03;
//	public GameObject cube04;
//	public GameObject cube05;
#endif


	public Light light1;
	
	public float juice = 20f;
	
	public float[] spec;
	
	public float c1;
	public float c2;
	public float c3;
	public float c4;

	int noteKey;
	
	public GameObject noteBlack;
	public GameObject noteWhite;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		spec = AudioListener.GetSpectrumData(64,0,FFTWindow.Hamming);
//		spec = AudioListener.GetOutputData (64,0);  
		/*
	c1 = 64hz
	c3 = 256hz
	c4 = 512hz
	*/
		c1 = spec[2] + spec[4] + spec[3];
		c2 = spec[11] + spec[12] + spec[13];
		c3 = spec[22] + spec[23] + spec[24];
		c4 = spec[44] + spec[45] + spec[45] + spec[46] + spec[47] + spec[48];
		
//		cube01.gameObject.transform.localScale = new Vector3(20f,c1*juice,1f);
//		cube02.gameObject.transform.localScale = new Vector3(20f,c2*juice,1f);
//		cube03.gameObject.transform.localScale = new Vector3(20f,c3*juice,1f);
//		cube04.gameObject.transform.localScale = new Vector3(20f,c4*juice,1f);



		if (100 * (c1+c3+c4) > 2) {
			Debug.Log (100 * (c3 + c4));

//			light1.gameObject.SetActive (false);


			noteKey = Random.Range (0, 2);

			
			if (noteKey == 0){
//				Debug.Log(note.GetComponent<SpriteRenderer> ().sprite.ToString());
				Instantiate(noteBlack, new Vector2(8, -2), Quaternion.identity);

//				(Texture2D)LoadAssetAtPath("Assets/Art/Pixel/notes/note_black.png", typeof(Sprite)) as Sprite);

//				note.GetComponent<SpriteRenderer> ().sprite = Resources.Load("Assets\\Art\\Pixel\\note_black", typeof(Sprite)) as Sprite;
			} else {
				Instantiate(noteWhite, new Vector2(8, -2), Quaternion.identity);

//				note.GetComponent<SpriteRenderer> ().sprite = Resources.Load("Assets\\Art\\Pixel\\notes", typeof(Sprite)) as Sprite;
			}


//			Debug.Log ("Note to hit =" + noteKey);

			StartCoroutine (DelaySpawn ());

		} else {
			light1.gameObject.SetActive(true);
		}

	}

	IEnumerator DelaySpawn()
	{
		float timeToWait = 0.48f;
		yield return new WaitForSeconds(timeToWait);
	}
	
}
