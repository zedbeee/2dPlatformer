using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_2d : MonoBehaviour
{

    //Running Stuff
    public float moveSpeed = 1f;
    public float walkSpeed = 0.1f;
    private float horizontalMove = 0f;

    //Jumping Stuff
    
    public float jumpForce = 1f;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime = 1f;


    //Animation stuff
    Animator animator;
    private Rigidbody2D playerBody;
    SpriteRenderer spriteRenderer;
    private float animState;
    private bool isJumping;
    private bool isGrounded;
    private bool isTurning;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (animator.GetInteger("animState") == 0 ){
           animator.SetInteger("animState", 1);
       }


    }

    void Update(){
            horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        
       // isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);
        if (playerBody != null){
            ApplyInput();
        }
    }
    
    private void ApplyInput() { 

        //Run-Walk Left
        if (Input.GetKey("a")) {
            if (animator.GetInteger("animState") == 1 ){
            //Walk
            animator.SetBool("isRunning", true);
            animator.SetInteger("animState", 2);
            playerBody.velocity = new Vector2(-walkSpeed, playerBody.velocity.y);
            spriteRenderer.flipX = true;
            } 
            //Run
            else {
            animator.SetInteger("animState", 3);
            playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
            }
        }

        //Run Right
        if (Input.GetKey("d")) {
            if (animator.GetInteger("animState") == 1 ){
            animator.SetInteger("animState", 2);
            playerBody.velocity = new Vector2(walkSpeed, playerBody.velocity.y);
            spriteRenderer.flipX = false;
            }
            else {
            animator.SetInteger("animState", 3);
            playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);

            }
        } 
        //Skid and end walk
        if (Input.GetKeyUp("a") && animator.GetInteger("animState") == 3) {
            animator.SetInteger("animState", 4);
            playerBody.velocity = new Vector2(-walkSpeed, playerBody.velocity.y); 
            animator.SetBool("isRunning", false);

        }
        if (Input.GetKeyUp("d") && animator.GetInteger("animState") == 3) {
            animator.SetInteger("animState", 4);
            playerBody.velocity = new Vector2(walkSpeed, playerBody.velocity.y); 
            animator.SetBool("isRunning", false);
       }

       
    }

    private void endSkid(){
        animator.SetInteger("animState", 1);
        playerBody.velocity = new Vector2(0, playerBody.velocity.y); 
    }

    private void walkCancel(){
        if (animator.GetBool("isRunning") == false){
        animator.SetInteger("animState", 1);
        playerBody.velocity = new Vector2(0, playerBody.velocity.y); 
        }
    }

    void setAnimationState(){
        if (horizontalMove == 0 ) {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
        if (playerBody.velocity.y == 0 ) {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }
}
