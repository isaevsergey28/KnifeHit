using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KnifeScore : MonoBehaviour
{
  private TextMeshProUGUI _scoreText;
  private int _score;

  private void Start()
  {
    ActiveKnife.onKnifeIsStuckInLog += IncrementKnifeScore;
    _scoreText = GetComponent<TextMeshProUGUI>();
    _score = 0;
    _scoreText.text = _score.ToString();
  }

  private void OnDisable()
  {
    ActiveKnife.onKnifeIsStuckInLog -= IncrementKnifeScore;
  }

  private void IncrementKnifeScore()
  {
    _score++;
    _scoreText.text = _score.ToString();
  }
}
