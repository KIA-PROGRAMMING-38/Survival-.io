using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public ObjectPool<Bullet> BulletPool { private get; set; }
    public BulletStat Stat = new BulletStat();
    private float _elapsedTime;
    private float _activateTime = 2f;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;    
    
    public Vector2 Direction { get => Stat.Direction; set => Stat.Direction = value; }
    public float Speed { get => Stat.BulletSpeed; set => Stat.BulletSpeed = value; }
    public IBulletMovingPattern MovingPattern { private get; set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();              
    }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _activateTime && gameObject.activeSelf == true)
        {
            _elapsedTime = 0f;
            Deactivate();
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {        
        if (target.CompareTag(TagLiteral.ENEMY) || target.CompareTag(TagLiteral.BOX)) 
        {
            Hit(target);
        }
    }

    private void Initialize()
    {
        _rigidbody.gravityScale = 0;

        RigidbodyConstraints2D constraints = RigidbodyConstraints2D.FreezeRotation;
        _rigidbody.constraints = constraints;

        _renderer.sprite = Stat.Sprite;
    }


    public void Move()
    {
        //MovingPattern.Do();
    }

    private void Hit(Collider2D target)
    {
        Health targetObject = target.gameObject.GetComponent<Health>();
        targetObject.TakeDamage(Stat.CurrentBulletDamage);
        Deactivate();
    }

    private void Deactivate()
    {        
        gameObject.SetActive(false);
        BulletPool.Release(this);
    }
        
}
