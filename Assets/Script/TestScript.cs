using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private PauseManager pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = GameObject.Find("PauseManager").GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // move to left
        if(!pause.isPaused)
        {
            transform.Translate(Vector2.right * 1f * Time.deltaTime);
        }

        
    }

    
}
