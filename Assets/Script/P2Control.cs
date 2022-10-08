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
    CapsuleCollider2D ccol;
    bool crouch = false;

    [Header("PowerUp")]
    SpriteGlowEffect SpriteGlowEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ccol = GetComponent<CapsuleCollider2D>();
        SpriteGlowEffect = GetComponent<SpriteGlowEffect>();
        SpriteGlowEffect.GlowColor = new Color(0, 0, 1, 1);
    }
    void Update()
    {
        Vector2 velocityVector = rb.velocity;
        velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);

        rb.velocity = velocityVector;

        if (crouch == true)
        {
            ccol.offset = new Vector2(0, -0.01f);
            ccol.size = new Vector2(1, 0.5f);
            transform.localScale = new Vector3(1.6348f, 1.6348f, 1.6348f);
        }
        else if (crouch == false)
        {
            ccol.offset = new Vector2(0, 0);
            ccol.size = new Vector2(1, 1);
            transform.localScale = new Vector3(1.6348f, 3, 1.6348f);
        }

        if (Input.GetKeyDown(downButton))
        {
            crouch = true;
            moveAccel = 4f;
            maxSpeed = 6f;
            jumpAccel = 4f;
            Debug.Log("crouching");
        }
        else if (Input.GetKeyUp(downButton))
        {
            crouch = false;
            moveAccel = 4f;
            maxSpeed = 8f;
            jumpAccel = 5f;
            Debug.Log("standing");

        }
        // read input
        if (Input.GetKey(upButton) && isOnGround)
        {
            jump();
        }
    }

    void jump()
    {
        rb.AddForce(Vector2.up * jumpAccel, ForceMode2D.Impulse);
        isOnGround = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isOnGround = true;
        }
    }

    public void Slow()
    {
        moveAccel = 2f;
        maxSpeed = 4f;
        jumpAccel = 3f;
        SpriteGlowEffect.GlowColor = new Color(2, 2, 0, 10);
        Invoke("ResetSpeed", 5);
    }

    public void Stun()
    {
        moveAccel = 0f;
        maxSpeed = 0f;
        jumpAccel = 0f;
        SpriteGlowEffect.GlowColor = new Color(1, 0, 2, 5);
        Invoke("ResetSpeed", 5);
    }

    public void Speedup()
    {
        moveAccel = 8f;
        maxSpeed = 12f;
        jumpAccel = 10f;
        SpriteGlowEffect.GlowColor = new Color(0, 2, 0, 5);
        Invoke("ResetSpeed", 5);
    }

    public void ResetSpeed()
    {
        moveAccel = 4f;
        maxSpeed = 8f;
        jumpAccel = 5f;
        SpriteGlowEffect.GlowColor = new Color(0, 0, 1, 1);
    }
    public void pausePlayer()
    {
        moveAccel = 0f;
        maxSpeed = 0f;
        jumpAccel = 0f;
    }
}
