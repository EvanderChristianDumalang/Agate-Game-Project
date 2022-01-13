using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    public float falltime;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "P2")
        {
            Invoke("delay", falltime);
            
        }
        else if (collision.gameObject.tag == "P1")
        {
            Invoke("delay", falltime);
            
        }
    }

    void delay()
    {
        gameObject.SetActive(false);
        Invoke("resetPlatform", 2f);
    }
    void resetPlatform()
    {
        gameObject.SetActive(true);
    }
}
