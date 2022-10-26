using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_System : MonoBehaviour
{
    public static int score; 
    private Text scoreText;
    
    void Start() 
    {
        scoreText = GetComponent<Text>();
        score = 0;
    }

    void Update() 
    {
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "" + score;
    }

    public static void AddPoints(int _pointsToAdd)
    {
        score += _pointsToAdd;
    }
}
