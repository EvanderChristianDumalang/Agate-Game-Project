using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Rigidbody2D rg;

    public float force;
    
    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Trampoline")
        {
            rg.AddForce ( Vector2.up * force,ForceMode2D.Impulse);
        }
    }
}
