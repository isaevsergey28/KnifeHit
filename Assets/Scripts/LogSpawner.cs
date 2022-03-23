using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _logSpawnPos;

    private void Start()
    {
        StageController.onStartPlainStage += SpawnLog;
        StageController.onStartBossFightStage += SpawnBoss;
    }

    private void OnDisable()
    {
        StageController.onStartPlainStage -= SpawnLog;
        StageController.onStartBossFightStage -= SpawnBoss;
    }

    private void SpawnLog()
    {
        LevelSettings levelSettings = GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings();
        Instantiate(levelSettings.GetLogPrefab(),
            _logSpawnPos, Quaternion.identity).GetComponentInChildren<SpriteRenderer>().sprite = levelSettings.GetRandomLogSprite();
    }

    private void SpawnBoss()
    {
        LevelSettings levelSettings = GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings();
        Instantiate(levelSettings.GetLogPrefab(),
            _logSpawnPos, Quaternion.identity).GetComponentInChildren<SpriteRenderer>().sprite = levelSettings.GetRandomBossSprite();
    }
}
