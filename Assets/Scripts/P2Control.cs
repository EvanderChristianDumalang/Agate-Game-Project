using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteGlow;


public class P2Control : MonoBehaviour
{
    [Header("Movement")]
    public KeyCode upButton = KeyCode.UpArrow;
    public KeyCode downButton = KeyCode.DownArrow;
    public float moveAccel = 4f;
    public float maxSpeed = 8f;
    private Rigidbody2D rb;

    [Header("Jump")]
    public float jumpAccel = 5f;
    private bool isOnGround;

    [Header("Crouch")]
    private CapsuleCollider2D ccol;
    private bool crouch = false;

    [Header("PowerUp")]
    public float speedUpDuration = 5f;
    public float slowDownDuration = 5f;
    public float stunDuration = 3f;
    public bool isStunned = false;
    private SpriteGlowEffect SpriteGlowEffect;

    // Variable for start speed & jump
    private float startMoveAccel;
    private float startMaxSpeed;
    private float startJumpAccel;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ccol = GetComponent<CapsuleCollider2D>();
        SpriteGlowEffect = GetComponent<SpriteGlowEffect>();
        SpriteGlowEffect.GlowColor = new Color(0, 0, 1, 1);
        isStunned = false;

        // Assign start speed & jump
        startMoveAccel = moveAccel;
        startMaxSpeed = maxSpeed;
        startJumpAccel = jumpAccel;
    }
    void Update()
    {
        Move();

        if (!isStunned) // isStunned == false
        {
            // Read input
            if (Input.GetKeyDown(upButton) && isOnGround)
            {
                animator.SetBool("isJumping", true);
                Jump();
            }
            else if (Input.GetKeyUp(upButton))
            {
                animator.SetBool("isJumping", false);
            }

            if (Input.GetKeyDown(downButton))
            {
                animator.SetBool("isCrouching", true);
                crouch = true;
                Crouch();
                CrouchCheck();
            }
            else if (Input.GetKeyUp(downButton))
            {
                animator.SetBool("isCrouching", false);
                crouch = false;
                ResetSpeed();
                CrouchCheck();
            }
        }
    }

    void Move()
    {
        Vector2 velocityVector = rb.velocity;
        velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);

        rb.velocity = velocityVector;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpAccel, ForceMode2D.Impulse);
        isOnGround = false;
    }

    void Crouch()
    {
        moveAccel -= 2f;
        maxSpeed -= 2f;
        jumpAccel -= 5f;  
    }

    void CrouchCheck()
    {
        if (crouch == true)
        {
            ccol.offset = new Vector2(0, -0.2f);
            ccol.size = new Vector2(1, 0.5f);
        }
        else if (crouch == false)
        {
            ccol.offset = new Vector2(0, 0.15f);
            ccol.size = new Vector2(1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    public void Speedup()
    {
        moveAccel += 6f;
        maxSpeed += 6f;
        jumpAccel += 10f;
        SpriteGlowEffect.GlowColor = new Color(0, 2, 0, 5);
        Invoke("ResetSpeed", speedUpDuration);
    }

    public void Slow()
    {
        moveAccel -= 2f;
        maxSpeed -= 2f;
        jumpAccel -= 3f;
        SpriteGlowEffect.GlowColor = new Color(2, 2, 0, 10);
        Invoke("ResetSpeed", slowDownDuration);
    }

    public void Stun()
    {
        moveAccel = 0f;
        maxSpeed = 0f;
        jumpAccel = 0f;
        SpriteGlowEffect.GlowColor = new Color(1, 0, 2, 5);
        //Invoke("ResetSpeed", stunDuration);
    }

    public void ResetSpeed()
    {
        // Use start speed & jump to reset
        moveAccel = startMoveAccel;
        maxSpeed = startMaxSpeed;
        jumpAccel = startJumpAccel;
        SpriteGlowEffect.GlowColor = new Color(0, 0, 1, 1);
    }

    public void PausePlayer()
    {
        moveAccel = 0f;
        maxSpeed = 0f;
        jumpAccel = 0f;
    }
}
