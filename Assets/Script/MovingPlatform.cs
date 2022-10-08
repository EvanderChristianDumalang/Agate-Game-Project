using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float moveSpeed;
    bool moveRight;
    Vector2 startPos;
    float a;

    private void Start()
    {
        startPos = gameObject.transform.position;
        a = Random.Range(0, 2);
        if (a < 1)
        {
            moveRight = false;
        }
        else
        {
            moveRight = true;
        }
        moveSpeed = Random.Range(1, 4);
    }

    void Update()
    {
        
        if (transform.position.x > startPos.x + 2f){
            moveRight = false;
        }
        else  if (transform.position.x < startPos.x - 2f)
        {
            moveRight = true;
        }

        if (moveRight){
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

}
