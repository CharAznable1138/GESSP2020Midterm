﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] GameObject scoreDisplay;
    private ScoreManager scoreManager;
    private Text finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreDisplay.GetComponent<ScoreManager>();
        finalScoreText = GetComponent<Text>();
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = $"Confirmed Kills: {scoreManager.Score}";
    }
}