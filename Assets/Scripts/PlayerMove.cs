using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 2;
    public float doubleJumpSpeed = 1.5f;
    private bool canDoubleJump;
    Rigidbody2D rb2D;
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        if((Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space"))){

            if(CheckGround.isGrounded) {
                canDoubleJump = true;
                animator.SetBool("Falling", false);
                animator.SetBool("Grounded", true);
            // Salto
            rb2D.velocity   = new Vector2(rb2D.velocity.x, jumpSpeed);

            }
            else {
                animator.SetBool("Grounded", false);
                if((Input.GetKeyDown("w") || Input.GetKeyDown("up") || Input.GetKeyDown("space"))) {
                    if(canDoubleJump) {
                        animator.SetBool("DoubleJump", true);
                        // Salto
                        rb2D.velocity   = new Vector2(rb2D.velocity.x, doubleJumpSpeed);

                        canDoubleJump = false;
                    }
                }
            }
              
        }
        if(CheckGround.isGrounded==false) {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if(CheckGround.isGrounded==true){
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
            Debug.Log("Falling == false");
        }
        if(rb2D.velocity.y < 0.1){
            animator.SetBool("Falling", true);
            animator.SetBool("VelocidadZero", false);
            Debug.Log("Falling == true");
               
        }else if(rb2D.velocity.y >= 0 ){
               
            animator.SetBool("Falling", false);
            animator.SetBool("VelocidadZero", false);
            Debug.Log("Falling == false");
        }
        if(rb2D.velocity.y == 0) {
            animator.SetBool("VelocidadZero", true);
        }
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            // Movimiento hacia la derecha
            rb2D.velocity   = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            // Movimiento hacia la izquierda
            rb2D.velocity   = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

        }else {
            // Que este quieto al no pulsar una tecla
            rb2D.velocity   = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);

        }

       
        if(betterJump) {
            if(rb2D.velocity.y < 0){
                
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*(fallMultiplier)*Time.deltaTime;
            }
            if(rb2D.velocity.y > 0 && !Input.GetKey("space") && !Input.GetKey("w") && !Input.GetKey("up")){
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*(lowJumpMultiplier)*Time.deltaTime;
                
            }
        }
    }
}
