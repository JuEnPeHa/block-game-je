using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    private int currentScore;
    public Text scoreText;
    public Text levelText;
    
    void Awake()
    {
        instance = this;
        //UPDATE UI
        UpdateUI();
    }

    public void Addscore(int score)
    {
        currentScore += score;
        //UPDATE UI
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore.ToString("D5");
    }
    
}
