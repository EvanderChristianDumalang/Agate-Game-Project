using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    
    [SerializeField]
    private string nextSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Delay());
        if (collision.gameObject.tag == "P1")
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else if (collision.gameObject.tag == "P2")
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
    }
}
