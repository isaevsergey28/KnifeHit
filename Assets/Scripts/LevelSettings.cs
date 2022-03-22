using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private int _stageKnivesCount;
    [SerializeField] private GameObject _logPrefab;
    [SerializeField] private Sprite[] _logSprites;
    [SerializeField] private GameObject _breakingLogPrefab;
    [SerializeField] private GameObject _activeKnifePrefab;
    [SerializeField] private GameObject _stuckKnifePrefab;
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _breakingApplePrefab;
    
    public int GetStageKnivesCount()
    {
        return _stageKnivesCount;
    }
    
    public GameObject GetLogPrefab()
    {
        return _logPrefab;
    }
    
    public GameObject GetBreakingLogPrefab()
    {
        return _breakingLogPrefab;
    }
    
    public GameObject GetActiveKnifePrefab()
    {
        return _activeKnifePrefab;
    }
    
    public GameObject GetStuckKnifePrefab()
    {
        return _stuckKnifePrefab;
    }
    
    public Sprite GetRandomLogSprite()
    {
        return _logSprites[Random.Range(0 , _logSprites.Length)];
    }

    public GameObject GetApplePrefab()
    {
        return _applePrefab;
    }
    
    public GameObject GetBreakingApplePrefab()
    {
        return _breakingApplePrefab;
    }
}
