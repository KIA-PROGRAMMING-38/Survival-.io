using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _speed = CharacterStat.DEFAULT_SPEED; // test value < ���� ������ �޾ƿ� ��
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    IMovable character;    

    private Vector2 _currentPosition;
    private Vector2 _directionVector;
    private Vector2 _movingRouteVector;
    private bool _isFacingDirection;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        character = GetComponentInParent<IMovable>();    
    }      

    private void FixedUpdate()
    {
        _directionVector = character.Direction;        
        _currentPosition = _rigidbody.position;
        _movingRouteVector = _directionVector * _speed * Time.fixedDeltaTime;        
        _rigidbody.MovePosition(_currentPosition + _movingRouteVector);
        
        if (_directionVector.x != 0) // �¿� �Է��� ���� ���� üũ
        {
            _isFacingDirection = _directionVector.x < 0; // true : Left, false : Right
        }
    }

    private void LateUpdate()
    {        
        _spriteRenderer.flipX = _isFacingDirection;        
    }
}

//public class EnemyMovement : MonoBehaviour
//{
//    public float _speed = 1f;
//    private Rigidbody2D _rigidbody;
//    private SpriteRenderer _spriteRenderer;
//    private Rigidbody2D _target;
//    private void Awake()
//    {
//        _rigidbody = GetComponent<Rigidbody2D>();
//        _spriteRenderer = GetComponent<SpriteRenderer>();
//    }
//    private void OnEnable()
//    {
//        _target = GameManager.Instance.Player.GetComponent<Rigidbody2D>();
//    }
//    private void FixedUpdate()
//    {
//        Vector2 directionVector = _target.position - _rigidbody.position;
//        Vector2 nextVector = directionVector * _speed * Time.fixedDeltaTime;
//        _rigidbody.MovePosition(_rigidbody.position + nextVector);        
//    }

