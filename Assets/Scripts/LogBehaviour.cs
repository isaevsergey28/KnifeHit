using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(WheelJoint2D))]
public class LogBehaviour : MonoBehaviour
{
    private List<LogRotationInfo> _activeRotationInfos = new List<LogRotationInfo>();
    private WheelJoint2D _wheelJoint;
    private JointMotor2D _jointMotor;
    private Coroutine _rotateCoroutine;
    private Coroutine _slowRotationCoroutine;

    private void Start()
    {
        GameManager.onVictory += BreakLog;
        GameManager.onLose += StopRotationLog;
        _wheelJoint = GetComponent<WheelJoint2D>();
        _jointMotor = _wheelJoint.motor;
        SetRotationsSettings();
        Rotate();
    }

    private void OnDisable()
    {
        GameManager.onVictory -= BreakLog;
        GameManager.onLose -= StopRotationLog;
    }

    private void SetRotationsSettings()
    {
        LogRotationInfo[] logRotationInfos = GameServicesProvider.instance.GetService<GameManager>()
            .GetCurrentLevelSettings().GetLogRotationsInfo().ToArray();
        for (int i = 0; i < 3; i++)
        {
            _activeRotationInfos.Add(logRotationInfos[Random.Range(0,logRotationInfos.Length)]);
        }
    }
    
    private void Rotate()
    {
        _rotateCoroutine = StartCoroutine(MakeRotations());
    }

    private IEnumerator MakeRotations()
    {
        int currentRotationIndex = 0;
        while (true)
        {
            _jointMotor.motorSpeed = _activeRotationInfos[currentRotationIndex].speed;
            _wheelJoint.motor = _jointMotor;
            if (_activeRotationInfos[currentRotationIndex].isSlowDown)
                _slowRotationCoroutine = StartCoroutine(SlowDown(currentRotationIndex));
            yield return new WaitForSeconds(_activeRotationInfos[currentRotationIndex].duration);
            currentRotationIndex++;
            currentRotationIndex = currentRotationIndex < _activeRotationInfos.Count ? currentRotationIndex : 0;
        }
    }

    private IEnumerator SlowDown(int currentRotationIndex)
    {
        int divider = 10;
        float timeOffset = _activeRotationInfos[currentRotationIndex].duration / (float) divider;
        for (int i = 0; i < divider; i++)
        {
            yield return null;
            _jointMotor.motorSpeed -= _activeRotationInfos[currentRotationIndex].speed / (float) divider;
            _wheelJoint.motor = _jointMotor;
            yield return new WaitForSeconds(timeOffset);
        }
    }

    private void StopRotationLog()
    {
        StopCoroutine(_rotateCoroutine);
        if(_slowRotationCoroutine != null) StopCoroutine(_slowRotationCoroutine);
        _jointMotor.motorSpeed = 0;
        _wheelJoint.motor = _jointMotor;
    }

    private void BreakLog()
    {
        Instantiate(GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().GetBreakingLogPrefab(),
            transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
