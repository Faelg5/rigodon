using UnityEngine;
using System.Collections;

public class MovePosition : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public GameObject hero;

	void FixedUpdate() {
		var rb2d = GetComponent<Rigidbody2D> ();
		hero = GameObject.Find ("hero");
		rb2d.MovePosition (new Vector2 (rb2d.position.x + 1, 0));
	}

	void OnCollisionEnter(Collision2D collision2D) {

		ContactPoint2D contactPoint2D = collision2D.contacts [0];
		Vector2 pos = contactPoint2D.point;

		Destroy(hero);

	}

}
