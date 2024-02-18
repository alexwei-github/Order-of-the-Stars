using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;
    public float moveSpeed; 
    public float targetSpeed;
    private Vector2 moveInput;

    public float acceleration;
    public float decceleration;
    public float power;
    private float accelerationRate;


    public float jumpForce;
    private bool isGrounded;
    private bool isJumping;
    private float lastGroundedTime;
    private float lastJumpTime;
    public float jumpCutForce;
    public float airRes;
    public float gravityScaleMult;
    private float gravityScale;

    public static PlayerMovement instance;
    public bool canMove = true; 

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
        anim = GetComponent<Animator>();
        Physics2D.queriesHitTriggers = false;

        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    void Update(){
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //flipping player left and right
        if(moveInput.x > 0.1f){
            transform.localScale = Vector3.one;
        }
        if(moveInput.x < -0.1f){
            transform.localScale = new Vector3(-1,1,1);
        }

        anim.SetBool("run", Mathf.Abs(moveInput.x) > 0.1f);
        anim.SetBool("grounded", IsGrounded());
    }

    private void FixedUpdate(){

        float targetSpeed = moveInput.x * moveSpeed;
        float speedDifference = targetSpeed - rb.velocity.x;
        if((Mathf.Abs(targetSpeed) > 0.01f)){
            accelerationRate = acceleration;
        }
        else{
            accelerationRate = decceleration;
        }
        float movement = Mathf.Pow(Mathf.Abs(speedDifference) * accelerationRate, power) * Mathf.Sign(speedDifference);
        //slows you down in air
        if(canMove){
        if(IsGrounded()){
            rb.AddForce(movement * Vector2.right);
        }
        else{
            rb.AddForce((movement/airRes) * Vector2.right );
        }
        if(Mathf.Abs(rb.velocity.x) < 0.5f){
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        if(IsGrounded() && moveInput.y > 0.1f) 
        {
            Jump();
        }
        //jump determined by how long you hold up
        if(rb.velocity.y > 0 && moveInput.y < 0.1f){
            jumpCut();
        }
        //makes gravity bigger when u fall
        if( rb.velocity.y < 0){
            rb.gravityScale = gravityScale * gravityScaleMult;
        }
        else{
            rb.gravityScale = gravityScale;
        }
        }
        
    }


    private void Jump(){
        rb.AddForce(new Vector2(0f, moveInput.y * jumpForce), ForceMode2D.Impulse);
        //lastGroundedTime = 0;
        //lastJumpTime = 0;
        isJumping = true;

    }

    public void jumpCut(){
        if(rb.velocity.y > 0 && !IsGrounded()){
            rb.AddForce(Vector2.down * rb.velocity.y * (1 / jumpCutForce), ForceMode2D.Impulse);    
        }
    }

    bool IsGrounded(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.01f, 0), Vector2.down, 0.2f);
        return hit.collider != null;
    }

}
