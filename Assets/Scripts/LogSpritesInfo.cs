using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LogSpritesInfo", menuName = "NewLog")]
public class LogSpritesInfo : ScriptableObject
{
    [SerializeField] private Sprite _logSprite;
    [SerializeField] private GameObject _breakingLogPrefab;

    public Sprite GetLogSprite()
    {
        return _logSprite;
    }

    public GameObject GetBreakingLogPrefab()
    {
        return _breakingLogPrefab;
    }
}
