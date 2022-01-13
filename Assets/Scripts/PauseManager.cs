using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [HideInInspector] public bool isPaused;
    public GameObject pausePopUp;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            pausePopUp.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePopUp.gameObject.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
