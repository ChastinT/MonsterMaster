using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TMP_Text scoreText = null;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
         if (scoreText != null)
        {
        scoreText.text = "Score: " + score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
           scoreText.text = "Score: " + score;  
        }
    }

    public void AddPoints()
    {
        score += 1;
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public int getScore()
    {
        return score;
    }
}
