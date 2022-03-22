using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSizeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField]  RectTransform _rectTransformAppleImage;
    
    private RectTransform _rectTransformScoreTextObject;
    private int _scoreTextLength = 1;

    private void Start()
    {
        _scoreText = transform.GetComponentInChildren<TextMeshProUGUI>();
        _rectTransformAppleImage = GetComponent<RectTransform>();
        _rectTransformScoreTextObject = _scoreText.gameObject.GetComponent<RectTransform>();
    }
    
    private void Update()
    {
        IncreaseScoreRectTransform();
    }

    private void IncreaseScoreRectTransform()
    {
        if(_scoreTextLength != _scoreText.text.Length)
        {
            _rectTransformAppleImage.anchoredPosition =
                new Vector2(_rectTransformAppleImage.anchoredPosition.x - 20, _rectTransformAppleImage.anchoredPosition.y);
            _rectTransformAppleImage.sizeDelta =
                new Vector2(_rectTransformAppleImage.sizeDelta.x + 40, _rectTransformAppleImage.sizeDelta.y);

            _rectTransformScoreTextObject.anchoredPosition = 
                new Vector2(_rectTransformScoreTextObject.anchoredPosition.x + 20, _rectTransformScoreTextObject.anchoredPosition.y);
            _rectTransformScoreTextObject.sizeDelta = 
                new Vector2(_rectTransformScoreTextObject.sizeDelta.x + 40, _rectTransformScoreTextObject.sizeDelta.y);

            _scoreTextLength = _scoreText.text.Length;
        }
    }

}
