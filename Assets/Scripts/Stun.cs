using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stun : MonoBehaviour
{
    private GameObject player1;
    private P1Control p1Control;
    private GameObject player2;
    private P2Control p2Control;
    private SpriteRenderer stunSprite;

    //public Text p1;
    //public Text p2;

    void Awake()
    {
        player1 = GameObject.Find("P1");
        player2 = GameObject.Find("P2");

        //Komponen player movement
        p1Control = player1.GetComponent<P1Control>();
        p2Control = player2.GetComponent<P2Control>();

        stunSprite = GetComponent<SpriteRenderer>();
    }

    //Check object masuk kedalam trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P2")
        {
            //p1.text = "Time to Stop!";
            stunSprite.enabled = false;
            StartCoroutine(StunPlayer1());
        } 
        else if (other.tag == "P1")
        {
            //p2.text = "Time to Stop!";
            stunSprite.enabled = false;
            StartCoroutine(StunPlayer2());
        }
    }

    IEnumerator StunPlayer1()
    {
        p1Control.isStunned = true;
        p1Control.Stun();
        yield return new WaitForSeconds(p1Control.stunDuration);
        p1Control.isStunned = false;
        p1Control.ResetSpeed();
        Destroy(gameObject);
    }

    IEnumerator StunPlayer2()
    {
        p2Control.isStunned = true;
        p2Control.Stun();
        yield return new WaitForSeconds(p2Control.stunDuration);
        p2Control.isStunned = false;
        p2Control.ResetSpeed();
        Destroy(gameObject);
    }
}
