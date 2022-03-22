using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelSettings _currentLevelSettings;
    
    public static Action onVictory;
    public static Action onLose;
    
    private AllKnives _allKnives;

    private void Awake()
    {
        GameServicesProvider.instance.Register(this);
    }

    private void Start()
    {
        ActiveKnife.onKnifeIsStuckInLog += CheckVictory;
        ActiveKnife.onKnifeHitKnife += AnnounceLose;
        _allKnives = GetComponent<AllKnives>();
        UIManager.instance.Init();
    }

    private void OnDisable()
    {
        ActiveKnife.onKnifeIsStuckInLog -= CheckVictory;
        ActiveKnife.onKnifeHitKnife -= AnnounceLose;
        GameServicesProvider.instance.Unregister(this);
    }

    public LevelSettings GetCurrentLevelSettings()
    {
        return _currentLevelSettings;
    }

    private void CheckVictory()
    {
        if (_currentLevelSettings.GetStageKnivesCount() == _allKnives.GetActiveKnives().Count)
        {
            _allKnives.ChangeKnivesSettings(transform);
            _allKnives.ClearKnivesList();
            onVictory?.Invoke();
        }
    }

    private void AnnounceLose()
    {
        onLose?.Invoke();
        StartCoroutine(ShowLoseCanvas());
    }

    private IEnumerator ShowLoseCanvas()
    {
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.Show<LoseCanvas>();
    }
}
