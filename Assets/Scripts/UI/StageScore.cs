using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageScore : MonoBehaviour
{
    private TextMeshProUGUI _stageScoreText;
    private int _stageCount;
    private string _stageScoreKey = "StageScore";
    private const string _stageText = "stage";
    
    private void Start()
    {
        _stageScoreText = GetComponent<TextMeshProUGUI>();
        ShowStageScore();
    }

    private void ShowStageScore()
    {
        if (PlayerPrefs.HasKey(_stageScoreKey))
        {
            _stageCount = PlayerPrefs.GetInt(_stageScoreKey);
        }
        else
        {
            _stageCount = 0;
            PlayerPrefs.SetInt(_stageScoreKey, _stageCount);
        }

        _stageScoreText.text = _stageText + " " + _stageCount;
    }
}
