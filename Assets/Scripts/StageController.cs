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

    private int _stageNumber;
    private int _spawnBossStageCount;
    private int _bossesCompleted;
    
    private void Start()
    {
        GameManager.onVictory += EndCurrentStage;
        StartCoroutine(StartFirstStage());
        _spawnBossStageCount = GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings()
            .GetSpawnBossStageCount();
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
            _bossesCompleted = Mathf.Clamp(_bossesCompleted, 0,
                GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings()
                    .GetKnifeSpritesCount() - 1);
            onEndBossFightStage?.Invoke(_bossesCompleted);
            onEndStage?.Invoke();
            UIManager.instance.ShowImmediately<GiftCanvas>().OnShow();
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