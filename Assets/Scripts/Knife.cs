using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected BoxCollider2D _boxCollider;
    
    public void SetDynamicPhysics()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        _boxCollider.isTrigger = true;
        MakeRandomMove();
    }
    
    protected void MakeRandomMove()
    {
        _rigidbody.AddForce(new Vector2(Random.Range(-5, 6), Random.Range(0, 6)), ForceMode2D.Impulse);
        _rigidbody.gravityScale = 2;
    }
}
