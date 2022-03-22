using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageNumber : MonoBehaviour
{
    private TextMeshProUGUI _stageNumberText;
    private int _stageNumber;
    private const string _stageText = "stage";

    private void Start()
    {
        StageController.onStartStage += IncrementStageNumberText;
        _stageNumberText = GetComponent<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        StageController.onStartStage -= IncrementStageNumberText;
    }

    private void IncrementStageNumberText()
    {
        _stageNumber++;
        _stageNumberText.text = _stageText + " " + _stageNumber;
    }
}
