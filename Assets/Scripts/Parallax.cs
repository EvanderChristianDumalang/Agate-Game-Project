using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //Parallax Effect Script
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        //check start position
        startpos = transform.position.x;
        //check the length
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        //how far we move relative to the camera
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        //check how far we move 
        float dist = (cam.transform.position.x * parallaxEffect);

        //move the camera
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        //looping the background
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
