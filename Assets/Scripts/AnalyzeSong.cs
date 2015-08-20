using UnityEngine;
using System.Collections;

public class AnalyzeSong : MonoBehaviour
{

#region members
    public float juice = 20.0f;
    public float[] spec;
    public float c1;
    public float c2;
    public float c3;
    public float c4;
//    public int noteKey;
    public int noteCount;
    public GameObject noteBlack;
    public GameObject noteWhite;
    public GameObject mainCamera;
    public Light light1;
    public AudioSource audio;
#endregion
#if DEBUG
    public GameObject cube01;
    public GameObject cube02;
    public GameObject cube03;
    public GameObject cube04;
    public GameObject cube05;
#endif

    // Use this for initialization
	void Start () {

		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		audio = mainCamera.GetComponent<AudioSource>();

		noteCount = 1;

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		spec = audio.GetSpectrumData(64,0,FFTWindow.Hamming);
#if DEBUG
        double dspTime = AudioSettings.dspTime;
#endif
        Debug.Log("Current time audio system: "+dspTime);
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



		if (1000 * (c3+c4) > 0.1) {
			Debug.Log (100 * (c3 + c4));

//			light1.gameObject.SetActive (false);


//			noteKey = Random.Range (0, 2);

//			InvokeRepeating("SpawnNote", 0.0f, 2.0f);

//			Invoke("SpawnNote", 0.1f);

			SpawnNote();
			noteCount += 1;



//			Debug.Log ("Note to hit =" + noteKey);



//			StartCoroutine (DelaySpawn ());



		} else {
			light1.gameObject.SetActive(true);

		}

	}

//	IEnumerator DelaySpawn()
//	{
//		float timeToWait = 5f;
//
//		yield return new WaitForSeconds (timeToWait);
//		SpawnNote ();
//
//
//	}

	void SpawnNote(){

        int noteKey = Random.Range(0, 2);

		if (noteKey == 0){
			//				Debug.Log(note.GetComponent<SpriteRenderer> ().sprite.ToString());
			Instantiate(noteBlack, new Vector2(12, -2), Quaternion.identity);
			
			//				(Texture2D)LoadAssetAtPath("Assets/Art/Pixel/notes/note_black.png", typeof(Sprite)) as Sprite);
			
			//				note.GetComponent<SpriteRenderer> ().sprite = Resources.Load("Assets\\Art\\Pixel\\note_black", typeof(Sprite)) as Sprite;
		} else {
			Instantiate(noteWhite, new Vector2(12, -2), Quaternion.identity);
			
			//				note.GetComponent<SpriteRenderer> ().sprite = Resources.Load("Assets\\Art\\Pixel\\notes", typeof(Sprite)) as Sprite;
		}
	}
	
}
