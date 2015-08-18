using UnityEngine;
using System.Collections;

public class EnemyMoveI : MonoBehaviour {
	
		public float speed = 2.0f;
		public float speedFactor = 1.0f;
		
		
		// Use this for initialization
		void Start () {
		speed = 2.0f;
		}
		
		
		
		// Update is called once per frame
		void Update ()
		{
			//move the enemy
			//transform.Translate (Vector3.right * ( speed * speedFactor));
			
			//public static function MoveTowards(current: Vector3, target: Vector3, maxDistanceDelta: float): Vector3;
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x + 1,0,0), (speed * speedFactor) / Time.deltaTime);
			Debug.Log ((speed * speedFactor) / Time.deltaTime);
			//Debug.Log ("Update:"+Time.deltaTime);
		}
		
		void OnCollisionEnter(Collision collisionInfo)
		{
			Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
			Debug.Log("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
			Debug.Log("Their relative velocity is " + collisionInfo.relativeVelocity);
		}
		
	}