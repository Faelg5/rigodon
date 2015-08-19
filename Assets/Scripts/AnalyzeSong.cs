using UnityEngine;
using System.Collections;

public class AnalyzeSong : MonoBehaviour {

	public GameObject cube01;
	public GameObject cube02;
	public GameObject cube03;
	public GameObject cube04;
	public GameObject cube05;

	public Light light1;
	
	public float juice = 20f;
	
	public float[] spec;
	
	public float c1;
	public float c2;
	public float c3;
	public float c4;


	public Transform note;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
		
		cube01.gameObject.transform.localScale = new Vector3(20f,c1*juice,1f);
		cube02.gameObject.transform.localScale = new Vector3(20f,c2*juice,1f);
		cube03.gameObject.transform.localScale = new Vector3(20f,c3*juice,1f);
		cube04.gameObject.transform.localScale = new Vector3(20f,c4*juice,1f);



		if (100 * (c3+c4) > 0.19) {
			Debug.Log (100 * (c1 + c2 + c3 + c4));
			light1.gameObject.SetActive (false);
			Instantiate(note, new Vector2(c1*300, c2*100), Quaternion.identity);
			StartCoroutine (DelaySpawn ());
		} else {
			light1.gameObject.SetActive(true);

		}

	}

	IEnumerator DelaySpawn()
	{
		float timeToWait = 1.0f;
		yield return new WaitForSeconds(timeToWait);
	}
	
}
