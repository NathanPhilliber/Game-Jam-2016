using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 150f;
	public float maxSpeed = 2.5f;
	public float jumpForce = 200f;
	public Transform groundCheck;
	public PlayerGroundCollider groundCollider;
	private static List<GameObject> alivePlayers;
	public Camera2DFollow camera;

	public int dimension;
	public float maxHealth = 100f;

    Animator anim;

	public SpriteRenderer sprite;
	//[HideInInspector] public bool facingLeft = true;


	//private bool grounded = false;
	//private Animator anim;
	private Rigidbody rb;
	private bool dead = false;
	private float health;


	// Use this for initialization
	void Awake () 
	{
        anim = GetComponentInChildren<Animator>();
		rb = GetComponent<Rigidbody>();

	}

	void Start(){
		health = maxHealth;
		if (alivePlayers == null) {
			alivePlayers = new List<GameObject> ();
		}
		alivePlayers.Add (gameObject);
		//Physics.IgnoreLayerCollision (8,9);
	}



	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.P)) {
			string outs = "Players Alive: ";
			for (int i = 0; i < alivePlayers.Count; i++) {
				outs += alivePlayers[i].ToString() + " ";
			}
			print (outs);
		}

		if (health < maxHealth) {
			health++;
		}
		//grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if (WorldControlManager.enabledWorld == dimension) {
			if (Input.GetButtonDown ("Jump") && groundCollider.grounded) {
				jump = true;
				groundCollider.grounded = false;
			}


		}
	}



	public void Damage(float damage){
		camera.Shake (new Vector3(Random.Range(-5,5),5,0));
		health -= Mathf.Abs(damage);
		if (health <= 0) {
			Die ();
		}
	}

	void Die(){
		print("DEAD!!!");
		transform.Translate (new Vector3(0, 0, -100f));
		dead = true;
		alivePlayers.Remove (gameObject);
		//Give the enemies new targets

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < enemies.Length; i++) {
			if (enemies [i].GetComponent<EnemyBehavior> ().target == gameObject) {
				enemies [i].GetComponent<EnemyBehavior> ().target = GetRandomAlivePlayer ();
			}
		}
	}

	void FixedUpdate()
	{
		float h = 0f;
		if (WorldControlManager.enabledWorld == dimension) {
			h = Input.GetAxis ("Horizontal");
		}


		anim.SetFloat("speed", Mathf.Abs(h));

		if (h * rb.velocity.x < maxSpeed)
			rb.AddForce(Vector2.right * h * moveForce);


		if (Mathf.Abs (rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector2(Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);

		if (Mathf.Abs(h) <= 0.1f) {
			rb.velocity = new Vector3(0,rb.velocity.y,0);
		}

		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

		if (jump)
		{
			//anim.SetTrigger("Jump");
			rb.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}


	void Flip()
	{
		sprite.flipX = !sprite.flipX;

		facingRight = !facingRight;

	}

	public static GameObject GetRandomAlivePlayer(){
		return alivePlayers[Random.Range(0,alivePlayers.Count)];
	}
}
