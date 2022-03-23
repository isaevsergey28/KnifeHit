using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : ScreenView
{
    [SerializeField] private TextMeshProUGUI _knivesCountScoreText;
    [SerializeField] private TextMeshProUGUI _stageScoreText;
    [SerializeField] private TextMeshProUGUI _appleCountText;
    [SerializeField] private GameObject _transactionLevelPanel;
    [SerializeField] private Button _restartButton;
    
    private const string _knivesCountScoreKey = "KnivesCountScore";
    private const string _appleScoreKey = "AppleCountScore";
    private const string _stageScoreKey = "StageNumberScore";
    private int _knivesCount;
    private int _appleCount;
    private int _stageNumber;

    public override void Init()
    {
        _restartButton.onClick.AddListener(DarkenScene);
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
    
    private void DarkenScene()
    {
        _transactionLevelPanel.SetActive(true);
        Image transactionleLevelImage = _transactionLevelPanel.GetComponent<Image>();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transactionleLevelImage.DOColor(
            new Color(transactionleLevelImage.color.r, transactionleLevelImage.color.g, transactionleLevelImage.color.b, 1), 1f));
        sequence.AppendCallback(StartGame);
    }
    
    private void StartGame()
    {
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loadOperation.isDone)
        {
            yield return null;
        }
    }
}
