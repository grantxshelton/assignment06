using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class creditsHighScore : MonoBehaviour
{
    public Text HighScores;
    public Text playerName;
    public Text yourScore;
    public int num_scores = 10;

     void Start()
    {
        string path = "Assets/scores.txt";
        string line;
        string[] fields;
        string[] playerNames = new string[num_scores];
        int[] playerScores = new int[num_scores];
        int scores_read = 0;

        HighScores.text = ""; // clear the scores box

        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream && scores_read < num_scores)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            HighScores.text += fields[0] + " : " + fields[1] + "\n";
            scores_read += 1;
        }
    }

    void Update()
    {
        if(ReadInput.playerName == null)
        {
            playerName.text = "Player1";
        }
        else
        {
            playerName.text = ReadInput.playerName.ToUpper();
        }

        yourScore.text = ScoreController.HighestScore.ToString();
        
    }
}
