using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public static Action onStartStage;
    public static Action onEndStage;

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
        yield return null;
        onStartStage?.Invoke();
    }
    
    private void EndCurrentStage()
    {
        onEndStage?.Invoke();
        StartCoroutine(WaitForNextStage());
    }

    private IEnumerator WaitForNextStage()
    {
        yield return new WaitForSeconds(3f);
        LoadNextStage();
    }

    private void LoadNextStage()
    {
        onStartStage?.Invoke();
    }
}