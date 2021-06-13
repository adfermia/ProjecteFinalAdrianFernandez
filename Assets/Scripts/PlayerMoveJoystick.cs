using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove = 0f;
    private float verticallMove = 0f;

    public Joystick joystick;

     public float runSpeedHorizontal = 2;
     public float runSpeed = 1.25f;
    public float jumpSpeed = 2;
    public float doubleJumpSpeed = 1.5f;
    private bool canDoubleJump;
    Rigidbody2D rb2D;
   
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update() {
          if (horizontalMove>0)
        {
            // Movimiento hacia la derecha
            
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }else if (horizontalMove<0)
        {
            // Movimiento hacia la izquierda
            
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

        }else {
            // Que este quieto al no pulsar una tecla
            animator.SetBool("Run", false);

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
        if(rb2D.velocity.y < -0.1){
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
        horizontalMove = joystick.Horizontal*runSpeedHorizontal;
        transform.position+=new Vector3(horizontalMove,0,0)*Time.deltaTime*runSpeed;

      

       
    }
    public void jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            animator.SetBool("Falling", false);
            animator.SetBool("Grounded", true);
            // Salto
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);

        }
        else
        {
            animator.SetBool("Grounded", false);

            if (canDoubleJump)
            {
                animator.SetBool("DoubleJump", true);
                // Salto
                rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);

                canDoubleJump = false;
            }

        }
    }

}
