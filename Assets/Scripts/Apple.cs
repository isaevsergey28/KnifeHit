using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static Action onDestroy;

    private void Start()
    {
        GameServicesProvider.instance.Register(this);
    }

    private void OnDisable()
    {
        GameServicesProvider.instance.Unregister(this);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out ActiveKnife knife))
        {
            onDestroy?.Invoke();
            BreakApple();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void BreakApple()
    {
        Instantiate(GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().GetBreakingApplePrefab(),
            transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
