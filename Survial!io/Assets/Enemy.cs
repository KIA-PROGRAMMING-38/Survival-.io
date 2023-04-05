using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 1f;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    public Rigidbody2D _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Vector2 directionVector = _target.position - _rigidbody.position;
        Vector2 nextVector = directionVector * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVector);        
    }
    private void LateUpdate()
    {
        _spriteRenderer.flipX = _target.position.x < _rigidbody.position.x;
    }
}
