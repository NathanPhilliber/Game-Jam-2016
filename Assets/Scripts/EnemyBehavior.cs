using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public GameObject target;
	public PlayerGroundCollider groundCollider;
	public float moveForce = 150f;
	public float maxSpeed = 2.5f;
	public float jumpForce = 200f;

	public float inRange = 1f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (Mathf.Abs (target.transform.position.x - transform.position.x) > inRange) {
			MoveTowardsTarget ();
		}
	}

	void MoveTowardsTarget(){
		float h = Mathf.Sign (target.transform.position.x-transform.position.x);

		if (h * rb.velocity.x < maxSpeed) {
			rb.AddForce (Vector2.right * h * moveForce);
		}

		if (Mathf.Abs (rb.velocity.x) > maxSpeed) {
			rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);
		}
	}
}
