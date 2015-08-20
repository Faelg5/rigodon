using UnityEngine;
using System.Collections;

public class MovePosition : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public float speedFactor = 1.0f;

	public GameObject hero;
    public GameObject enemy;

    public bool facingRight = true;

    void Start()
    {
    }

	void FixedUpdate() {
		var rb2d = GetComponent<Rigidbody2D> ();
		//hero = GameObject.Find ("hero");
        if (moveSpeed * speedFactor < 0 && facingRight)
        {
            enemyFlip();
        } else if (moveSpeed * speedFactor > 0 && !facingRight) {
            enemyFlip();
        }

		rb2d.MovePosition (new Vector2 (rb2d.position.x + moveSpeed * speedFactor * Time.fixedDeltaTime, 1.5f) );
	}

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Border") {
//            hero = GameObject.Find ("hero");
            Destroy(hero);

			Application.LoadLevel("GameOver");
        }
    }

    void enemyFlip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
