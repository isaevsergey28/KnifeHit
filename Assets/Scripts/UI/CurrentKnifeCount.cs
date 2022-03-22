using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentKnifeCount : MonoBehaviour
{
  private TextMeshProUGUI _scoreText;
  private int _scoreNumber;
  private string _knivesCountScoreKey = "KnivesCountScore";
  
  private void Start()
  {
    ActiveKnife.onKnifeIsStuckInLog += IncrementKnifeScore;
    _scoreText = GetComponent<TextMeshProUGUI>();
    _scoreNumber = 0;
    _scoreText.text = _scoreNumber.ToString();
  }

  private void OnDisable()
  {
    ActiveKnife.onKnifeIsStuckInLog -= IncrementKnifeScore;
    PlayerPrefs.SetInt(_knivesCountScoreKey, _scoreNumber);
  }

  private void IncrementKnifeScore()
  {
    _scoreNumber++;
    _scoreText.text = _scoreNumber.ToString();
  }
}
