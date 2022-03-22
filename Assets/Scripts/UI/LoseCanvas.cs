using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseCanvas : ScreenView
{
    [SerializeField] private TextMeshProUGUI _currentGameScore;
    
    private const string _knivesCountScoreKey = "KnivesCountScore";
    private const string _stageScoreKey = "StageNumberScore";
    public override void Init()
    {
    }

    private void OnEnable()
    {
        _currentGameScore.text = "record: \nstage " + " " + PlayerPrefs.GetInt(_stageScoreKey) + 
                                 "\nscore " + PlayerPrefs.GetInt(_knivesCountScoreKey);
    }
}
