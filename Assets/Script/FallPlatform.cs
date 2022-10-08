using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "P2")
        {
            Invoke("delay", 0.5f);
            
        }
        else if (collision.gameObject.tag == "P1")
        {
            Invoke("delay", 1f);
            
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
