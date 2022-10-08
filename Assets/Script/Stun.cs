using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stun : MonoBehaviour
{
    GameObject Player1;
    P1Control P1Control;
    GameObject Player2;
    P2Control P2Control;

    //public Text p1;
    //public Text p2;

    void Awake()
    {
        Player1 = GameObject.Find("P1");
        Player2 = GameObject.Find("P2");

        //Komponen player movement
        P1Control = Player1.GetComponent<P1Control>();
        P2Control = Player2.GetComponent<P2Control>();
    }

    //Check object masuk kedalam trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P2")
        {
            //p1.text = "Time to Stop!";
            P1Control.Stun();
            Destroy (gameObject);
        } 
        else if (other.tag == "P1")
        {
            //p2.text = "Time to Stop!";
            P2Control.Stun();
            Destroy (gameObject);
        }
    }
}
