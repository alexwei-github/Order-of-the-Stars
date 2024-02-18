using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
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


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    void Update(){
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

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
        if(isGrounded){
            rb.AddForce(movement * Vector2.right);
        }
        else{
            rb.AddForce((movement/airRes) * Vector2.right );
        }


        if(isGrounded && moveInput.y > 0.1f) 
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
            rb.gravityScale = gravityScale / gravityScaleMult;
        }
        
    }

    private void Jump(){
        rb.AddForce(new Vector2(0f, moveInput.y * jumpForce), ForceMode2D.Impulse);
        //lastGroundedTime = 0;
        //lastJumpTime = 0;
        isJumping = true;

    }

    public void jumpCut(){
        if(rb.velocity.y > 0 && !isGrounded){
            rb.AddForce(Vector2.down * rb.velocity.y * (1 / jumpCutForce), ForceMode2D.Impulse);    
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == 6){
            isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.layer == 6){
            isGrounded = false;
        }
    }
}
