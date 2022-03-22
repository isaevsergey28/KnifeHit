using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static Action onDestroy;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out ActiveKnife knife))
        {
            onDestroy?.Invoke();
            BreakApple();
        }
    }
    
    private void BreakApple()
    {
        Instantiate(GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().GetBreakingApplePrefab(),
            transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
