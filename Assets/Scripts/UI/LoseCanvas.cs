using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseCanvas : ScreenView
{
    [SerializeField] private TextMeshProUGUI _currentGameScore;
    
    public override void Init()
    {
    }

    public void SetLosePanelValues(int currentStageNumber, int currentKnivesCount)
    {
        _currentGameScore.text = "stage " + currentStageNumber + "\nscore " + currentKnivesCount;
    }
}
