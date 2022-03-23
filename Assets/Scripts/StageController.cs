using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public static Action onStartPlainStage;
    public static Action onStartBossFightStage;
    public static Action<int> onEndBossFightStage;
    public static Action onEndStage;

    private int _stageNumber = 0;
    private int _spawnBossStageCount = 5;
    private int _bossesCompleted = 0;
    
    private void Start()
    {
        GameManager.onVictory += EndCurrentStage;
        StartCoroutine(StartFirstStage());
    }

    private void OnDisable()
    {
        GameManager.onVictory -= EndCurrentStage;
    }

    private IEnumerator StartFirstStage()
    {
        GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().RandomizeStageKnivesCount();
        yield return null;
        _stageNumber++;
        onStartPlainStage?.Invoke();
    }
    
    private void EndCurrentStage()
    {
        
        if (_stageNumber % _spawnBossStageCount == 0)
        {
            _bossesCompleted++;
            onEndBossFightStage?.Invoke(_bossesCompleted);
            onEndStage?.Invoke();
        }
        else
        {
            onEndStage?.Invoke();
        }
        StartCoroutine(WaitForNextStage());
    }

    private IEnumerator WaitForNextStage()
    {
        GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().RandomizeStageKnivesCount();
        yield return new WaitForSeconds(GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().
            GetWaitTimeBetweenStages());
        _stageNumber++;
        if (_stageNumber % _spawnBossStageCount == 0)
        {
            onStartBossFightStage?.Invoke();
        }
        else
        {
            onStartPlainStage?.Invoke();
        }
    }
}