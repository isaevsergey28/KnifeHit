using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckKnife : Knife
{
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
