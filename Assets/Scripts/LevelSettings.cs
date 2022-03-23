using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum CurrentStage
{
    Plain = 0,
    Boss = 1
}

[CreateAssetMenu(fileName = "LevelSettings", menuName = "LevelSettings")]
public class LevelSettings : ScriptableObject
{
    
    [SerializeField] private List<LogRotationInfo> _logRotationsInfo;
    [SerializeField] private int _maxKnivesCount;
    [SerializeField] private int _waitTimeBetweenStages;
    [SerializeField] private GameObject _logPrefab;
    [SerializeField] private Sprite[] _logSprites;
    [SerializeField] private Sprite[] _bossSprites;
    [SerializeField] private Sprite[] _knifeSprites;
    [SerializeField] private GameObject _breakingLogPrefab;
    [SerializeField] private GameObject _breakingBossPrefab;
    [SerializeField] private GameObject _activeKnifePrefab;
    [SerializeField] private GameObject _stuckKnifePrefab;
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _breakingApplePrefab;
    [Space]
    [Header("Max chance is 100")]
    [SerializeField] private int _appleSpawnChance = 25;
    [SerializeField] private int _knifeSpawnChance = 50;

    private int _stageKnivesCount;
    private CurrentStage _currentStage;
    
    public List<LogRotationInfo> GetLogRotationsInfo()
    {
        return _logRotationsInfo;
    }
    
    public int GetStageKnivesCount()
    {
        return _stageKnivesCount;
    }
    
    public int GetWaitTimeBetweenStages()
    {
        return _waitTimeBetweenStages;
    }
    
    public GameObject GetLogPrefab()
    {
        return _logPrefab;
    }
    
    public GameObject GetBreakingLogPrefab()
    {
        return _breakingLogPrefab;
    }
    
    public GameObject GetBreakingBossPrefab()
    {
        return _breakingBossPrefab;
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
        _currentStage = CurrentStage.Plain;
        return _logSprites[Random.Range(0 , _logSprites.Length)];
    }

    public Sprite GetRandomBossSprite()
    {
        _currentStage = CurrentStage.Boss;
        return _bossSprites[Random.Range(0 , _bossSprites.Length)];
    }
    
    public GameObject GetApplePrefab()
    {
        return _applePrefab;
    }
    
    public GameObject GetBreakingApplePrefab()
    {
        return _breakingApplePrefab;
    }

    public void RandomizeStageKnivesCount()
    {
        _stageKnivesCount = Random.Range(3, _maxKnivesCount + 1);
    }

    public int GetAppleSpawnChance()
    {
        return _appleSpawnChance;
    }
    
    public int GetKnifeSpawnChance()
    {
        return _knifeSpawnChance;
    }
    
    public Sprite GetKnifeSprite(int knifeIndex)
    {
        return _knifeSprites[knifeIndex];
    }

    public CurrentStage GetCurrentStage()
    {
        return _currentStage;
    }
}
