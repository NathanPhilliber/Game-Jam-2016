using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public GameObject target;
	public PlayerGroundCollider groundCollider;
	public float moveForce = 150f;
	public float maxSpeed = 2.5f;
	public float jumpForce = 200f;

	public float inRange = .4f;
	public float maxHealth;
	private float health;

	public SpriteRenderer sprite;
	private bool facingLeft;

	private Rigidbody rb;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		player = target.GetComponent<PlayerController> ();
		facingLeft = transform.position.x > target.transform.position.x;
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (Vector3.Distance(target.transform.position, transform.position) > inRange) {
			MoveTowardsTarget ();
		} else {
			player.Damage (10);

		}
	}

	public void Damage(float damage, bool knockback, Vector3 damagerPos){
		health -= damage;
		if (knockback) {
			Vector3 dir = damagerPos - transform.position;
			dir.Normalize ();
			rb.velocity = Vector3.zero;
			rb.AddForce(-dir*2, ForceMode.Impulse);
		}
		if (health <= 0) {
			Die ();
		}
	}

	public void Die(){
		Destroy (gameObject);
	}

	void MoveTowardsTarget(){
		float step = maxSpeed/(health/maxHealth) * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

		if (Random.Range (0,50) == 0) {
			rb.AddForce (new Vector3(0,Random.Range(0,50)-35,0));
		}

		if (transform.position.x - target.transform.position.x > 0 && facingLeft) {
			sprite.flipX = false;
			facingLeft = false;
		}

		if (transform.position.x - target.transform.position.x < 0 && !facingLeft) {
			sprite.flipX = true;
			facingLeft = true;
		}

		/*
		float xDir = Mathf.Sign (target.transform.position.x-transform.position.x);
		float yDir = Mathf.Sign (target.transform.position.y-transform.position.y);

		if (xDir * rb.velocity.x < maxSpeed) {
			rb.AddForce (Vector2.right * xDir * moveForce);
		}

		if (Mathf.Abs (rb.velocity.x) > maxSpeed) {
			rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);
		}
		*/

	}
}
