using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenView : MonoBehaviour
{
    public bool showOnInit;

    public virtual void Init()
    {
        Debug.Log(name);
    }
}
