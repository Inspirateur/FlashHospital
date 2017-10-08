using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
    public Animator animator;

	public float moveForce;			// Amount of force added to move the player left and right.
	public float maxSpeed;				// The fastest the player can travel in the x axis.
	public float jumpForce;			// Amount of force added when the player jumps.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded;			// Whether or not the player is grounded.
	private bool cared;			// Whether or not the player is on a car.
	private RaycastHit2D car;
	private int h;
	private Vector2 forceAdded;

	void Awake(){
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
	}


	void Update(){
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		cared = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Car"));
		car = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Car"));
        animator = GetComponent<Animator>();

		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetButtonDown ("Jump") && ( grounded || cared) ) {
			jump = true;
            animator.SetTrigger("Jumping");
		}
        
        animator.SetBool("Grounded", (grounded || cared) && !jump);
        animator.SetBool("Moving", (grounded || cared) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)));
        animator.SetBool("Falling", !(grounded || cared) && GetComponent<Rigidbody2D>().velocity.y < -1);

    }


	void FixedUpdate (){
		// Cache the horizontal input.
		if (Input.GetKey (KeyCode.RightArrow)) {
			h = 1;
			if (!facingRight) {
				Flip ();
			}
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			h = -1;
			if (facingRight) {
				Flip ();
			}
		} else {
			h = 0;
		}
		forceAdded = new Vector2 (0, 0);
		/*
		print (h);
		if (h == 0 && (grounded || cared)) {
			if (cared) {
				GetComponent<Rigidbody2D> ().velocity = car.rigidbody.velocity;
				print ("test");
			} else {
				GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, GetComponent<Rigidbody2D> ().velocity.y, 0f);
			}
		} else if (Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x) < maxSpeed) {
			// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
			// ... add a force to the player.
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * h * moveForce / 2);
		}
		if(Mathf.Abs(h) == 1)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(h*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		*/
		if (cared) {
			forceAdded += car.rigidbody.velocity;
		}
		if (h != 0) {
			if (Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x + moveForce * h) < maxSpeed) {
				if (grounded || cared) {
					forceAdded +=Vector2.right * h * moveForce;
				} else {
					forceAdded +=Vector2.right * h * moveForce / 2;
				}
			}
		} else {
			if (grounded) {
				if (Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x) <= 10f) {
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
				} else {
					forceAdded += -Vector2.right * Mathf.Sign (GetComponent<Rigidbody2D> ().velocity.x) * moveForce / 2;
				}
			} else if (cared){
				if (Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x) <= 10f+Mathf.Abs(car.rigidbody.velocity.x)) {
					GetComponent<Rigidbody2D> ().velocity = car.rigidbody.velocity;
				} else {
					forceAdded += -Vector2.right * Mathf.Sign (GetComponent<Rigidbody2D> ().velocity.x) * moveForce / 2;
				}
			} else {
				forceAdded += -Vector2.right * Mathf.Sign(GetComponent<Rigidbody2D> ().velocity.x)*moveForce/ 4;
			}
		}
		// If the player should jump...
		if(jump){
			// Add a vertical force to the player.
			forceAdded += new Vector2(0f, jumpForce);
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
		GetComponent<Rigidbody2D> ().AddRelativeForce (forceAdded);
	}
	
	
	void Flip (){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
