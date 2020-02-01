using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class playerControls : MonoBehaviour {
    
	private playerState state;

    private Rigidbody2D rb;
    private Collider2D collider;

    private float horMov;

    public bool grounded;
    private bool facingRight = true;

    public float runSpeed;
    public float maxRunSpeed;
    [Range(0,1)]
    public float runAccel;
    [Range(0,1)]
    public float runDrag;

    private bool jumping = false;
	private bool jumpAllowed = true;
	private bool canJump = true;
	private bool canControl = true;
    [Range(0,1)]
    public float drag = 1;
    public float gravityDropModifier = 2;

	public float jumpForce;
	private float jumpDuration = 0;
	public float jumpTime = .3f;

    private Vector2 platformMovementVector;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
		state = GetComponent<playerState>();
    }

    private void Update() {
        checkInput();

        if(!grounded && jumping) {
			jumpDuration += Time.fixedDeltaTime;
		}
    }

    private void FixedUpdate() {
        
        checkRun();

        if(jumping)
		{
			Jump();
		}

		if(grounded)
		{
			jumpDuration = 0;
		}
    }

    void checkInput()
	{				
		horMov = Input.GetAxisRaw("Horizontal");

		if(grounded)
		{
            setGravityScale(1);
			jumping = false;
			canJump = true;
			DetermineJumpButton();
		}
		
		JumpButton();

		if(rb.velocity.x > 0 && !facingRight)//if(horMov > 0 && !facingRight)
		{			
			Flip();
		}
		else if(rb.velocity.x < 0 && facingRight)//if(horMov <0 && facingRight)
		{			
			Flip();
		}


		if(state.currentPotentialPickup != null){
			if(Input.GetButtonDown(ProjectConstants.PICKUP_BUTTON)){
				print("picking up boss: " + state.currentPotentialPickup);
				state.pickup(state.currentPotentialPickup);
			}
		}
		if(state.currentInteractableObject != null){
			if(!state.currentInteractableObject.isInteracting){ //Hasn't interacted with this yet
				if(Input.GetButtonDown(ProjectConstants.INTERACT_BUTTON)){
					print("Interacted with object");
					state.currentInteractableObject.InteractedFirst();
					state.currentInteractableObject.isInteracting = true;	
				}
			}
			
		}
		// anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
		// anim.SetBool("grounded", grounded);
		// anim.SetFloat("vspeed", rb.velocity.y);

	}

    private void checkRun(){

        float runDir = (horMov != 0) ? Mathf.Sign(horMov) : 0;

        print("runDir: " + runDir);

        float modifier = (runDir == 0) ? runDrag : runAccel;

        Vector2 runForce = rb.velocity;

        if(runDir != 0){
            runForce += runDir * runSpeed * modifier * Vector2.right;
        }
        else{
            runForce -= (rb.velocity.x * modifier * Vector2.right);
        }

        runForce.x = Mathf.Clamp(runForce.x, -maxRunSpeed, maxRunSpeed);

        rb.velocity = runForce + platformMovementVector;
    }

    void Jump() {
		Vector2 jumpVector = rb.velocity;
		jumpVector.y = jumpForce;
				
		if(jumpDuration < jumpTime)
		{
			rb.velocity = jumpVector;//new Vector2(rb.velocity.x, jumpForce);
		}
	}

    void JumpButton()
	{

		//drag on player
		if(!Input.GetButton(ProjectConstants.JUMP_BUTTON))
		{
			if(rb.velocity.y >= 0)
			{
				Vector2 dragForce = rb.velocity;
				dragForce.y = rb.velocity.y * drag;

				rb.velocity = dragForce;

				if(!grounded)
				{
					jumpDuration = jumpTime;
				}

			}
		}


		if(Input.GetButton(ProjectConstants.JUMP_BUTTON) && jumpAllowed)
		{
			jumping = true;
			canJump = false;

			if(grounded)
			{
				//queue jumpdust
			}
		}

		if(jumpDuration >= jumpTime)
		{
			jumping = false;
			jumpAllowed = false;

			if(rb.velocity.y < 0)
			{
				setGravityScale(gravityDropModifier);
			}

		}			
	}

    void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

    void DetermineJumpButton() {
		if(grounded && !Input.GetButton("Jump"))
		{
			jumpAllowed = true;
		}
	}

    public Rigidbody2D getRigidBody(){return rb;}

    public void setGravityScale(float newScale){rb.gravityScale = newScale;}
}