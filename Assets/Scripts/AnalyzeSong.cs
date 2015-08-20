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

		spec = audio.GetSpectrumData(64,0,FFTWindow.Rectangular);
#if DEBUG
        double dspTime = AudioSettings.dspTime;
#endif
//        Debug.Log("Current time audio system: "+ dspTime); 
		/* c1 = 64hz c3 = 256hz c4 = 512hz */
		c1 = spec[2] + spec[4] + spec[3];
		c2 = spec[11] + spec[12] + spec[13];
		c3 = spec[22] + spec[23] + spec[24];
		c4 = spec[44] + spec[45] + spec[45] + spec[46] + spec[47] + spec[48];

		if (1000 * (c3+c4) > 0.1) {
//			Debug.Log (100 * (c3 + c4));

            int noteKey = Random.Range(0, 2);
			SpawnNote(noteKey);
			noteCount += 1;



		} else {
			light1.gameObject.SetActive(true);

		}

	}

	void SpawnNote(int noteKey){
        
        //Debug.Log("Note key :" + noteKey);
		if (noteKey == 0) {
			Instantiate(noteBlack, new Vector2(12, -4), Quaternion.identity);
		} else {
			Instantiate(noteWhite, new Vector2(12, -2), Quaternion.identity);
		}
	}
	
}
