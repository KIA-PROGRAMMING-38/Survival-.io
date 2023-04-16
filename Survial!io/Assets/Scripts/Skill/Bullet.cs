using Assets.Scripts.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public ObjectPool<Bullet> BulletPool { private get; set; }
    public BulletStat Stat = new BulletStat();     
    private Vector3 _moveDirection;
    private float _speed = 1.5f;
    private float _elapsedTime;
    private float _activateTime = 3f;
    private Transform _target;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;

    public IBulletMovingPattern MovingPattern { private get; set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        Initialize();        
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

        _renderer.sprite = Stat.Sprite;
        
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
        MovingPattern.Do(Stat, _rigidbody);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
        BulletPool.Release(this);
    }
}
