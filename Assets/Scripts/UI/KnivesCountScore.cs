using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KnivesCountScore : MonoBehaviour
{
    private TextMeshProUGUI _knivesCountScoreText;
    private int _knivesCount;
    private string _knivesCountScoreKey = "KnivesCountScore";
    private const string _knivesCountText = "score";
    
    private void Start()
    {
        _knivesCountScoreText = GetComponent<TextMeshProUGUI>();
        ShowKnivesScore();
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

        _knivesCountScoreText.text = _knivesCountText + " " + _knivesCount;
    }
}
