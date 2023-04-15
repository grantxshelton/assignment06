
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Text pauseText;
    public Button resumeButton;
    public static bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        resumeButton.gameObject.SetActive(false); // hide the Resume button
        pauseText.gameObject.SetActive(false); //hide pause text

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC key pauses AND resumes
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (!isPaused)
        {
            pauseText.gameObject.SetActive(false); //hide pause text
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseText.gameObject.SetActive(true); //show pause text
        resumeButton.gameObject.SetActive(true); // show the Resume button
    }
    public void ResumeGame() // called from ESC; also attached to the resume button
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseText.gameObject.SetActive(false); //hide pause text
        resumeButton.gameObject.SetActive(false); // hide the Resume button while playing
    }
}