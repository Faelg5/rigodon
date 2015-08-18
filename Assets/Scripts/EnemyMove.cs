using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float speed;
	public float speedFactor;


	// Use this for initialization
	void Start () {

	}


	
	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate ()
	{
		//move the enemy
		//transform.Translate (Vector3.right * ( speed * speedFactor));
		
		//public static function MoveTowards(current: Vector3, target: Vector3, maxDistanceDelta: float): Vector3;
		transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x + 1,0,0), (speed * speedFactor/10));
		Debug.Log ((speed * speedFactor));
		//Debug.Log ("Update:"+Time.deltaTime);
	}


	void OnCollisionEnter(Collision c)
	{
//		Debug.Log("Detected collision between " + gameObject.name + " and " + c.collider.name);
//		Debug.Log("There are " + c.contacts.Length + " point(s) of contacts");
//		Debug.Log("Their relative velocity is " + c.relativeVelocity);
		if (c.collider.tag == "border") {
			Debug.Log("HMMM ! Un bon mulet !");
		}
	}
	
}
