using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  //Private components
  private Rigidbody2D rb;
  private BoxCollider2D coll;
  private SpriteRenderer sprite;
  private Animator anim;

  //Private variables
  [SerializeField] private LayerMask jumpableGround;

  //Input key for horizontal movement
  private float dirX;

  //Defining precision for velocity because the program is not 100% exact
  private float precisionSpeed = 0.00001f;
  [SerializeField] private float moveSpeed = 7f;
  [SerializeField] private float jumpForce = 7f;

  //Different states for the character, mammaged by numbers {0,1,2,3}
  private enum MovementState { idle, running, jumping, falling }

  [SerializeField] private AudioSource jumpSoundEffect;

  // Start is called before the first frame update
  void Start()
  {
    //Setting private components
    rb = GetComponent<Rigidbody2D>();
    coll = GetComponent<BoxCollider2D>();
    sprite = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    //Value of the axis ∈ [-1,1]
    dirX = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

    if(Input.GetButtonDown("Jump") && IsGrounded())
    {
      jumpSoundEffect.Play();
      rb.velocity = new Vector2(rb.velocity.x, jumpForce) ;
    }

    //Function call; switch animations
    UpdateAnimationState();
  }

  //Function to switch between animations
  private void UpdateAnimationState()
  {
    MovementState state;

    //Checking running steps
    if (dirX > 0f)
    {
      state = MovementState.running;
      sprite.flipX = false;
    }
    else if (dirX < 0f)
    {
      state = MovementState.running;
      //Flip animation when moving to the left
      sprite.flipX = true;
    }
    else
    {
      state = MovementState.idle;
    }

    //y-velocity positive means jumping-state
    if (rb.velocity.y > precisionSpeed)
    {
      state = MovementState.jumping;
    }
    //y-velocity negative means falling-state
    else if (rb.velocity.y < -precisionSpeed)
    {
      state = MovementState.falling;
    }

    //Update state with the number corresponding to {0,1,2,3}
    anim.SetInteger("state",(int)state);
  }

  //Function to check if the player is grounded and don't allow it to jump twice
  private bool IsGrounded()
  {
    //Physics2D.BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction )
    return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
  }
}
