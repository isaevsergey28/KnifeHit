using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingApple : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
