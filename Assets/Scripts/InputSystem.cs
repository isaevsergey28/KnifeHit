using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static Action onClick;

    private bool _isMobilePlatform;

    private void Awake()
    {
        GameServicesProvider.instance.Register(this);
#if UNITY_EDITOR || UNITY_STANDLONE
        _isMobilePlatform = false;
#else
          _isMobilePlatform = true;
#endif

    }

    private void OnDestroy()
    {
        GameServicesProvider.instance.Unregister(this);
    }

    private void Update()
    {
        if (_isMobilePlatform)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                onClick?.Invoke();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                onClick?.Invoke();
            }
        }
    }
}
