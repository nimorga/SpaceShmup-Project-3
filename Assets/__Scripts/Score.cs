using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private Text gameScore;

    void Start()
    {
        gameScore = GetComponent<Text>();
    }

    void Update()
    {
        gameScore.text =  "Score: " + score.ToString("#,0");
    }

    public void AddScore(int points){
        score += points;
        Update(); 
        //Debug.Log("Score added: " + score);
    }
}
