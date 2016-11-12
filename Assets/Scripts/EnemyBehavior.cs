using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public GameObject target;
	public PlayerGroundCollider groundCollider;
	private Collider collider;
	public float moveForce = 150f;
	public float maxSpeed = 2.5f;
	public float jumpForce = 200f;

	public float inRange = .4f;
	public float maxHealth;
	private float health;

	public SpriteRenderer sprite;
	private bool facingLeft;
	private bool ghosting = false;

	private Rigidbody rb;
	private PlayerController player;

    private Animator anim;
    private bool dead = false;

	public void SetTarget(GameObject tar){
		
		target = tar;
		player = target.GetComponent<PlayerController> ();
		facingLeft = transform.position.x > target.transform.position.x;
		if (rb != null) {
			rb.velocity = Vector3.zero;
			rb.ResetInertiaTensor ();
		}


	}

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();

		rb = GetComponent<Rigidbody> ();
		health = maxHealth;
		EnemySpawner.spawns++;
		if (target != null) {
			player = target.GetComponent<PlayerController> ();
			facingLeft = transform.position.x > target.transform.position.x;
		}
		collider = GetComponent<Collider> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (Vector3.Distance(target.transform.position, transform.position) > inRange) {
            if (!dead)
            {
                MoveTowardsTarget();
            }
		} else if(!dead) {
			player.Damage (10);
		}
	}



	public void Damage(float damage, bool knockback, Vector3 damagerPos){
		health -= damage;
		if (knockback) {
			Vector3 dir = damagerPos - transform.position;
			dir.Normalize ();
			rb.velocity = Vector3.zero;
			//rb.AddForce(-dir*2, ForceMode.Impulse);
		}
		if (health <= 0) {
            Die ();
		}
	}

	public void Die(){
        collider.enabled = false;
        dead = true;
        anim.SetTrigger("death");
		EnemySpawner.spawns--;
		Destroy (gameObject, 0.5f);
	}

	void MoveTowardsTarget(){

		if (Mathf.Abs (transform.position.y) > 120) {
			print ("I got lost... I'll just kill myself");
			Die ();
		}

		if (Mathf.Abs (transform.position.y - target.transform.position.y) > 5 && !ghosting) {
			collider.enabled = false;
			ghosting = true;
		} else if(Mathf.Abs (transform.position.y - target.transform.position.y) < 5 && ghosting){
			collider.enabled = true;
			ghosting = false;
		}

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

	}
}
