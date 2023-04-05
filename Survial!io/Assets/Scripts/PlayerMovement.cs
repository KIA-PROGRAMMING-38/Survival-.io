using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float _speed = 4f;
    public Vector2 _inputVec;
    private Rigidbody2D _rigidbody;
    
    private SpriteRenderer _renderer;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Vector2 nextVec = _inputVec.normalized * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }
    private void LateUpdate()
    {        
        if (_inputVec.x != 0) // x축을 기준으로
        {
            _renderer.flipX = _inputVec.x < 0; // 음수면 true를 줘서 flip, 양수면 false를 줘서 일반 스프라이트 재생
        }
    }
    private void OnMove(InputValue value)
    {
        _inputVec = value.Get<Vector2>();
    }
}
