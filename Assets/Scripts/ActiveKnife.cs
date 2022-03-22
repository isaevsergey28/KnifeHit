using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class ActiveKnife : Knife
{
    [SerializeField] private float _throwForce;

    public static Action onKnifeIsStuckInLog;
    public static Action onKnifeHitKnife;

    private readonly float _newColliderOffset = -0.6f;
    private readonly float _newColliderSize = 1.2f;
    private bool _isNotHit = true;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        InputSystem.onClick += MakePush;
    }

    private void OnDisable()
    {
        InputSystem.onClick -= MakePush;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isNotHit)
        {
            if (collision.collider.TryGetComponent(out Log log))
            {
                Vibration.VibratePop();
                _isNotHit = false;
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.bodyType = RigidbodyType2D.Kinematic;
                _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
                transform.parent = log.transform;
                ChangeKnifeCollider();
                onKnifeIsStuckInLog?.Invoke();
                enabled = false;
            }
            else if (collision.collider.TryGetComponent(out Knife knife))
            {
                Vibration.VibratePop();
                _isNotHit = false;
                int fallingForce = 15;
                Vector2 fallingDirection = transform.position - knife.transform.position;
                _rigidbody.velocity = fallingDirection * fallingForce;
                onKnifeHitKnife?.Invoke();
                enabled = false;
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
    private void MakePush()
    {
        _rigidbody.AddForce(new Vector2(0, _throwForce), ForceMode2D.Impulse);
        _rigidbody.gravityScale = 1;
    }

    private void ChangeKnifeCollider()
    {
        _boxCollider.offset = new Vector2(_boxCollider.offset.x, _newColliderOffset);
        _boxCollider.size = new Vector2(_boxCollider.size.x, _newColliderSize);
    }
}
