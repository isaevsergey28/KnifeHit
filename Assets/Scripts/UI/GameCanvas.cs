using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : ScreenView
{
    [SerializeField] private TextMeshProUGUI _currentKnivesCountScoreText;
    [SerializeField] private TextMeshProUGUI _currentApplesCountText;
    [SerializeField] private TextMeshProUGUI _currentStageNumberText;

    private const string _knivesCountScoreKey = "KnivesCountScore";
    private const string _appleScoreKey = "AppleCountScore";
    private const string _stageScoreKey = "StageNumberScore";
    private int _knivesCount;
    private int _appleCount;
    private int _stageNumber;
    private int _spawnBossStageCount = 5;
    
    public override void Init()
    {
    }

    private void Start()
    {
        StageController.onStartPlainStage += IncrementStageNumberText;
        ActiveKnife.onKnifeIsStuckInLog += IncrementKnifeScore;
        Apple.onDestroy += IncreaseAppleCount;
        CheckApplesScore();
    }

    private void OnDisable()
    {
        StageController.onStartPlainStage -= IncrementStageNumberText;
        ActiveKnife.onKnifeIsStuckInLog -= IncrementKnifeScore;
        Apple.onDestroy -= IncreaseAppleCount;
        SavePlayerPrefs(_stageScoreKey, _stageNumber);
        SavePlayerPrefs(_knivesCountScoreKey, _knivesCount);
        SavePlayerPrefs(_appleScoreKey, _appleCount);
        UIManager.instance.GetScreen<LoseCanvas>().SetLosePanelValues(_stageNumber, _knivesCount);
    }

    private void IncrementStageNumberText()
    {
        _stageNumber++;
        if (_stageNumber % _spawnBossStageCount == 0)
        {
            _currentStageNumberText.text = "Boss Fight";
        }
        else
        {
            _currentStageNumberText.text = "stage " + _stageNumber;
        }
    }

    private void IncrementKnifeScore()
    {
        _knivesCount++;
        _currentKnivesCountScoreText.text = _knivesCount.ToString();
    }

    private void CheckApplesScore()
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

        _currentApplesCountText.text = _appleCount.ToString();
    }

    private void IncreaseAppleCount()
    {
        _appleCount++;
        _currentApplesCountText.text = _appleCount.ToString();
    }

    private void SavePlayerPrefs(string key, int value)
    {
        if (PlayerPrefs.GetInt(key) < value)
        {
            PlayerPrefs.SetInt(key,value);
        }
    }
}
