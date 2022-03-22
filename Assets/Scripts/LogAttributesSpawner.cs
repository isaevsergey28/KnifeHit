using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class LogAttributesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnDots;

    private Dictionary<GameObject, bool> _spawnDotsInfo = new Dictionary<GameObject, bool>();
    private int _appleSpawnChance = 25;
    private int _knifeSpawnChance = 50;
    private bool _isKnifeNotSpawned = true;
    private int _maxKnivesNumber = 3;
    
    private void Start()
    {
        FillSpawnDotsInfo();
        SpawnApple();
        SpawnKnives();
    }

    private void FillSpawnDotsInfo()
    {
        foreach (var spawnDot in _spawnDots)
        {
            _spawnDotsInfo.Add(spawnDot, false);
        }
    }

    private void SpawnApple()
    {
        foreach (var spawnDot in _spawnDotsInfo.ToList())
        {
            if (Random.Range(0, 101) < _appleSpawnChance + 1)
            {
                GameObject apple = Instantiate(GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().GetApplePrefab(),
                    spawnDot.Key.transform.position, Quaternion.identity, GetComponentInChildren<Log>().transform);
                _spawnDotsInfo[spawnDot.Key] = true;
                Vector3 dir = transform.position - apple.transform.position;
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                apple.transform.rotation = Quaternion.AngleAxis(angle + 90 , Vector3.forward);
                return;
            }
        }
    }

    private void SpawnKnives()
    {
        while (_isKnifeNotSpawned)
        {
            for (int i = 0; i < _maxKnivesNumber; i++)
            {
                if (Random.Range(0, 101) < _knifeSpawnChance + 1)
                {
                    int randomIndex = Random.Range(0, _spawnDots.Length);
                    if (_spawnDotsInfo[_spawnDots[randomIndex]] == false)
                    {
                        _spawnDotsInfo[_spawnDots[randomIndex]] = true;
                        GameObject stuckKnife = Instantiate(
                            GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings()
                                .GetStuckKnifePrefab(),
                            _spawnDots[randomIndex].transform.position, Quaternion.identity, GetComponentInChildren<Log>().transform);
                        _isKnifeNotSpawned = false;
                        
                        Vector3 dir = transform.position - stuckKnife.transform.position;
                        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                        stuckKnife.transform.rotation = Quaternion.AngleAxis(angle - 90 , Vector3.forward);
                    }
                }
            }
        }
    }
}
