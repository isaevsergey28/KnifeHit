using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(WheelJoint2D))]
public class LogBehaviour : MonoBehaviour
{
    [SerializeField] private List<LogRotationInfo> _logRotationsInfo;

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
        Rotate();
    }

    private void OnDisable()
    {
        GameManager.onVictory -= BreakLog;
        GameManager.onLose -= StopRotationLog;
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
            _jointMotor.motorSpeed = _logRotationsInfo[currentRotationIndex].speed;
            _wheelJoint.motor = _jointMotor;
            if (_logRotationsInfo[currentRotationIndex].isSlowDown)
                _slowRotationCoroutine = StartCoroutine(SlowDown(currentRotationIndex));
            yield return new WaitForSeconds(_logRotationsInfo[currentRotationIndex].duration);
            currentRotationIndex++;
            currentRotationIndex = currentRotationIndex < _logRotationsInfo.Count ? currentRotationIndex : 0;
        }
    }

    private IEnumerator SlowDown(int currentRotationIndex)
    {
        int divider = 10;
        float timeOffset = _logRotationsInfo[currentRotationIndex].duration / (float) divider;
        for (int i = 0; i < divider; i++)
        {
            yield return null;
            _jointMotor.motorSpeed -= _logRotationsInfo[currentRotationIndex].speed / (float) divider;
            _wheelJoint.motor = _jointMotor;
            yield return new WaitForSeconds(timeOffset);
        }
    }

    private void StopRotationLog()
    {
        StopCoroutine(_rotateCoroutine);
        StopCoroutine(_slowRotationCoroutine);
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
