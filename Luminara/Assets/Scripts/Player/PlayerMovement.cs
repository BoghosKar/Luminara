using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;



public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
   public float jumpForce;
   private float moveInput;
   private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpsValue;

    public AudioSource jumpaudio;
    public Animation jumpanim;

    private bool isJumpPressed;
    private float jumpBufferTimer;
    public float jumpBufferTime = 0.2f;

    private bool facingRight = true;

    public int HP;
    public int MaxHP;

    public bool is_alive;

    //HealthBar
    public HealthBarBehaviour HealthBar;

    //Menus
    public GameObject deadMenu;

    //public ParticleSystem deathParticle;
    public AudioSource deathSound;

    void Start()
    {
        MaxHP = 100;
        HP = MaxHP;

        HealthBar.SetHealth(HP,MaxHP);

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {

         
        // if (rb.velocity.y <= -2 && isGrounded)
        // {
        //     jumpanim.Play();
        // }



        if(Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(-Vector3.up * 110);
        }

        

        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(!isGrounded && extraJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            jumpanim.Play();
        }

        // Check if the jump button was pressed and start the jump buffer timer
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
            jumpBufferTimer = jumpBufferTime;
        }

        // Decrement the jump buffer timer
        if(jumpBufferTimer > 0)
        {
            jumpBufferTimer -= Time.deltaTime;
        }

        // If the player is grounded or still has extra jumps and the jump button was pressed within the buffer time, jump
        if((isGrounded || extraJumps > 0) && isJumpPressed && jumpBufferTimer > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            jumpaudio.Play();
        }

        // Reset the jump buffer variables
        isJumpPressed = false;
        jumpBufferTimer = 0;

        is_alive = HP > 0;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = ! facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void TakeDamage (int damage)
    {
        HP -= damage;
        HealthBar.SetHealth(HP,MaxHP);
        if (HP<= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        deathSound.Play();
        Destroy(gameObject);
        deadMenu.SetActive(true);
    }
}



