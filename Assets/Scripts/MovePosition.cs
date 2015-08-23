using UnityEngine;
using System.Collections;

public class MovePosition : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public float speedFactor = 1.0f;

	public GameObject hero;
    public GameObject enemy;

	public Transform positionX;

	public AudioClip audioClip1;
	public AudioClip audioClip2;
	public AudioClip audioClip3;
	public AudioClip audioClip4;



    public bool facingRight = true;
	
    void Start()
    {
	
		GetComponent<Animator>().Play("IdleTalk");


		StartCoroutine(startRunning());

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

	IEnumerator startRunning(){
		yield return new WaitForSeconds(2);
		GetComponent<Animator>().Play("Running");
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

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "AudioTrigger1") {
			Debug.Log("audioClip1 triggered");
			AudioSource.PlayClipAtPoint(audioClip1, new Vector2 (1,2));
		}
		else if (coll.gameObject.tag == "AudioTrigger2") {
			AudioSource.PlayClipAtPoint(audioClip2, new Vector2 (1,2));
		}
		else if (coll.gameObject.tag == "AudioTrigger3") {
			AudioSource.PlayClipAtPoint(audioClip3, new Vector2 (1,2));
		}
		else if (coll.gameObject.tag == "AudioTrigger4") {
			AudioSource.PlayClipAtPoint(audioClip4, new Vector2 (1,2));
		}

	}

}
