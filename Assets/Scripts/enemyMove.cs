using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {
	
	public int speedFactor = -1;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//move the enemy
		transform.Translate (Vector3.right * speedFactor * Time.deltaTime);
	

	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		print("Their relative velocity is " + collisionInfo.relativeVelocity);
	}
	
}
