using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Respawn : MonoBehaviour
{
    [Header("Respawn")]
    Vector2 currPosition;
    public CinemachineVirtualCameraBase cam;
    Vector2 resDist;
    private bool invincible = false;
    public int layer;
    Renderer rend;
    Color c;

    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    void Update()
    {
        resDist = new Vector2(-5, +3);
        currPosition = gameObject.transform.TransformPoint(resDist);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                gameObject.SetActive(false);
                Invoke("respawn", 2f);
            }
        }
    }
    public void respawn()
    {
        Physics2D.IgnoreLayerCollision(layer, 11, true);
        invincible = true;
        transform.position = currPosition;
        gameObject.SetActive(true);
        cam.Follow = gameObject.transform;
        c.a = 0.5f;
        rend.material.color = c;
        Invoke("resetInvincible", 3f);
    }
    void resetInvincible()
    {
        Physics2D.IgnoreLayerCollision(layer, 11, false);
        c.a = 1f;
        rend.material.color = c;
        invincible = false;
    }

    
}
