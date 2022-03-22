using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakingAppleCount : MonoBehaviour
{
    private TextMeshProUGUI _appleCountText;
    private int _appleCount;
    private string _appleScoreKey = "AppleScore";
    
    private void Start()
    {
        Apple.onDestroy += IncreaseAppleCount;
        _appleCountText = GetComponent<TextMeshProUGUI>();
        CheckAppleScore();
    }

    private void OnDisable()
    {
        Apple.onDestroy -= IncreaseAppleCount;
        PlayerPrefs.SetInt(_appleScoreKey, _appleCount);
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
    
    private void IncreaseAppleCount()
    {
        _appleCount++;
        _appleCountText.text = _appleCount.ToString();
    }
}
