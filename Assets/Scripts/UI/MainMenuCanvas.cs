using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuCanvas : ScreenView
{
    [SerializeField] private TextMeshProUGUI _knivesCountScoreText;
    [SerializeField] private TextMeshProUGUI _stageScoreText;
    [SerializeField] private TextMeshProUGUI _appleCountText;

    private const string _knivesCountScoreKey = "KnivesCountScore";
    private const string _appleScoreKey = "AppleCountScore";
    private const string _stageScoreKey = "StageNumberScore";
    private int _knivesCount;
    private int _appleCount;
    private int _stageNumber;
    
    public override void Init()
    {

    }

    private void Start()
    {
        ShowStageScore();
        CheckAppleScore();
        ShowKnivesScore();
    }

    private void ShowStageScore()
    {
        if (PlayerPrefs.HasKey(_stageScoreKey))
        {
            _stageNumber = PlayerPrefs.GetInt(_stageScoreKey);
        }
        else
        {
            _stageNumber = 0;
            PlayerPrefs.SetInt(_stageScoreKey, _stageNumber);
        }

        _stageScoreText.text = "stage " + _stageNumber;
    }

    private void CheckAppleScore()
    {
        if (PlayerPrefs.HasKey(_appleScoreKey))
        {
            _appleCount = PlayerPrefs.GetInt(_appleScoreKey);
        }
        else
        {
            _appleCount = 0;
            PlayerPrefs.SetInt(_appleScoreKey, _appleCount);
        }

        _appleCountText.text = _appleCount.ToString();
    }

    private void ShowKnivesScore()
    {
        if (PlayerPrefs.HasKey(_knivesCountScoreKey))
        {
            _knivesCount = PlayerPrefs.GetInt(_knivesCountScoreKey);
        }
        else
        {
            _knivesCount = 0;
            PlayerPrefs.SetInt(_knivesCountScoreKey, _knivesCount);
        }

        _knivesCountScoreText.text = "score " + _knivesCount;
    }
}
