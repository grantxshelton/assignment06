using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CreditButtons : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ReplayGame()
    {
        ScoreController.Lives = 3;
        ScoreController.Score = 0;
        SceneManager.LoadScene("Main");
    }
}
