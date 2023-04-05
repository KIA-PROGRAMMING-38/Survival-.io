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
        if (_inputVec.x != 0) // x���� ��������
        {
            _renderer.flipX = _inputVec.x < 0; // ������ true�� �༭ flip, ����� false�� �༭ �Ϲ� ��������Ʈ ���
        }
    }
    private void OnMove(InputValue value)
    {
        _inputVec = value.Get<Vector2>();
    }
}
