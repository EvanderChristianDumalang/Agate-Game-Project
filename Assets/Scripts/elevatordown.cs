using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatordown : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    private bool moving;
    private bool back;
    public float resetTime;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "P1")
        {
            moving = true;
            Invoke("resetPlatform", resetTime);
        }
        if (other.gameObject.tag == "P2")
        {
            moving = true;
            Invoke("resetPlatform", resetTime);
        }
    }

   // private void OnCollisionExit2D(Collision2D other) {
       // if (other.gameObject.tag == "P1")
        //{
           // moving = false;
        //}
    //}

    void resetPlatform()
    {
        moving = false;
        back = true;
        Invoke("backagain", 2f);
    }

    void backagain()
    {
        back = false;
    }

    private void Update() 
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
        if (back)
        {
            transform.position -= (velocity * Time.deltaTime);
        }
    }
}
