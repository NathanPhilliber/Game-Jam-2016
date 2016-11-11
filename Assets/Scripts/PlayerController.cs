using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 150f;
	public float maxSpeed = 2.5f;
	public float jumpForce = 200f;
	public Transform groundCheck;
	public PlayerGroundCollider groundCollider;

	public int dimension;
	public int maxHealth;


	//private bool grounded = false;
	//private Animator anim;
	private Rigidbody rb;


	// Use this for initialization
	void Awake () 
	{
		//anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () 
	{
		
		//grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if (WorldControlManager.enabledWorld == dimension) {
			if (Input.GetButtonDown ("Jump") && groundCollider.grounded) {
				jump = true;
				groundCollider.grounded = false;
			}
		}
	}

	void FixedUpdate()
	{
		float h = 0f;
		if (WorldControlManager.enabledWorld == dimension) {
			h = Input.GetAxis ("Horizontal");
		}


		//anim.SetFloat("Speed", Mathf.Abs(h));

		if (h * rb.velocity.x < maxSpeed)
			rb.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector2(Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);

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
		//Problem with flipping box collider, fix later
		/*facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;*/
	}
}
