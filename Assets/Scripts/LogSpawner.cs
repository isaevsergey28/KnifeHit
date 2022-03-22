using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _logSpawnPos;

    private void Start()
    {
        StageController.onStartStage += SpawnLog;
    }

    private void OnDisable()
    {
        StageController.onStartStage -= SpawnLog;
    }

    private void SpawnLog()
    {
        LevelSettings levelSettings = GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings();
        Instantiate(levelSettings.GetLogPrefab(),
            _logSpawnPos, Quaternion.identity).GetComponentInChildren<SpriteRenderer>().sprite = levelSettings.GetRandomLogSprite();
    }
}
