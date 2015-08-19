using UnityEngine;
using System.Collections;

public class MovePosition : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public float speedFactor = 1.0f;

	public GameObject hero;

	void FixedUpdate() {
		var rb2d = GetComponent<Rigidbody2D> ();
		//hero = GameObject.Find ("hero");
		rb2d.MovePosition (new Vector2 (rb2d.position.x + (moveSpeed * speedFactor * Time.fixedDeltaTime), 0) );
	}

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Border") {
//            hero = GameObject.Find ("hero");
            Destroy(hero);
        }
    }

}
