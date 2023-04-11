using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private Vector2 _moveDirection;
    private float _speed;
    private float _elapsedTime;
    private float _activateTime = 1f;
    private Transform _target;
    // range를 어떻게 설정해 줄 것인가 - 스킬 세부 구현에서 결정 

    public ObjectPool<Bullet> Pool { private get; set; }

    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Initialize();
        Move();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _activateTime)
        {
            _elapsedTime = 0f;
            Deactivate();
        }
    }

    private void Initialize()
    {
        _rigidbody.gravityScale = 0;

        RigidbodyConstraints2D constraints = RigidbodyConstraints2D.FreezeRotation;
        _rigidbody.constraints = constraints;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Deactivate();
        }
    }

    private void Move()
    {
        Transform bullet;
        bullet = GetComponent<Transform>();
        _moveDirection = transform.forward;
        _speed = 3f;
        bullet.Translate(_moveDirection * _speed, Space.World);
        
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
        Pool.Release(this);
    }
}
