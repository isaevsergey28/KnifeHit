using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class ActiveKnife : Knife
{
    [SerializeField] private float _throwForce;

    public static Action onKnifeIsStuckInLog;
    public static Action onKnifeHitKnife;

    private ParticleSystem _particleSystem;
    private readonly float _newColliderOffset = -0.6f;
    private readonly float _newColliderSize = 1.2f;
    private bool _isNotHit = true;

    private void Start()
    {
        InputSystem.onClick += MakePush;
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _particleSystem = GetComponent<ParticleSystem>();
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
                _particleSystem.Play();
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
                Vibration.Vibrate();
                _isNotHit = false;
                int fallingForce = 15;
                Vector2 fallingDirection = transform.position - knife.transform.position;
                _rigidbody.velocity = fallingDirection * fallingForce;
                onKnifeHitKnife?.Invoke();
                enabled = false;
            }
        }
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
