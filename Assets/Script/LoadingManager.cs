using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    private bool finishLoad = false;

    [SerializeField] private Text loadingTextBefore;
    [SerializeField] private Text loadingTextAfter;
    [SerializeField] private string nextScene;
    [SerializeField] private float loadingTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (loadingTextBefore.gameObject != null && loadingTextAfter.gameObject != null)
        {
            loadingTextBefore.gameObject.SetActive(true);
            loadingTextAfter.gameObject.SetActive(true);

            Color zero = new Color(loadingTextAfter.color.r, loadingTextAfter.color.g, loadingTextAfter.color.b, 0f);
            loadingTextAfter.color = zero;

            StartCoroutine(Loading(loadingTime));
        }
        else
        {
            Debug.Log("Assign both loading text first!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(finishLoad && Input.anyKey)
        {
            finishLoad = false;
            SceneManager.LoadScene(nextScene);
        }
    }

    IEnumerator FadeInText(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0f);
        while (i.color.a < 1f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    IEnumerator FadeOutText(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1f);
        while (i.color.a > 0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    IEnumerator Loading(float sec)
    {
        yield return new WaitForSeconds(sec);
        StartCoroutine(FadeOutText(1, loadingTextBefore));
        StartCoroutine(FadeInText(1, loadingTextAfter));

        // Wait until text fully appear
        yield return new WaitForSeconds(2);
        finishLoad = true;
    }
}
