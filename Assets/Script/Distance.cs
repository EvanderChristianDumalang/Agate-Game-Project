using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Distance : MonoBehaviour {
    [SerializeField]
    public Transform checkpointp1;
    public Transform checkpointp2;
    [SerializeField]
    private string nextSceneName;

    [SerializeField]
    public Text distanceText1;
    public Text distanceText2;

    [SerializeField]
    GameObject winp1;
    [SerializeField]
    GameObject winp2;
    [SerializeField]
    GameObject draw;

    // Calculated distance value
    private float distance1;
    private float distance2;

    GameObject Player1;
    GameObject Player2;

    P1Control P1Control;
    P2Control P2Control;

    void Awake()
    {
        Player1 = GameObject.Find("P1");
        Player2 = GameObject.Find("P2");

        P1Control = Player1.GetComponent<P1Control>();
        P2Control = Player2.GetComponent<P2Control>();
    }

    private void Update () {

        // Calculate distance value by X axis
        distance1 = (checkpointp1.transform.position.x -  Player1.transform.position.x);
        distance2 = (checkpointp2.transform.position.x -  Player2.transform.position.x);

        // Display distance value via UI text
        // distance.ToString("F1") shows value with 1 digit after period
        // so 12.234 will be shown as 12.2 for example
        // distance.ToString("F2") will show 12.23 in this case
        distanceText1.text = distance1.ToString("F1") + " M Left";
        distanceText2.text = distance2.ToString("F1") + " M Left";

        // If Cat reaches checkpoint then distance text shows "Finish!" word
        if (distance2 <= 0 && distance1 <= 0)
        {
            distanceText2.text = "Finish!";
            distanceText1.text = "Finish!";
            draw.SetActive(true);
        }
        else if (distance1 <= 0)
        {
            //StartCoroutine(Delay(2f));
            distanceText1.text = "Finish!";
            winp1.SetActive(true);
            Invoke("Delay", 2);
            P2Control.pausePlayer();
        }
        else if (distance2 <= 0)
        {
            distanceText2.text = "Finish!";
            winp2.SetActive(true);
            P1Control.pausePlayer();
        }

    }
    public void Delay()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    
}

