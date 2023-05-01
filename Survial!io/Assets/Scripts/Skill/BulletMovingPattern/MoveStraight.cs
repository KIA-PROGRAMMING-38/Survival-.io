using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    public float Speed { private get => _speed; set => _speed = value; }
    private float _speed;
    private Rigidbody2D _rigidbody;
    private Transform _target;
    private Vector2 _targetPosition;
    private Transform _player;
    private Vector2 _playerPosition;
    private Bullet _bullet;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GameManager.Instance.Player.transform;
        _bullet = GetComponent<Bullet>();
        Speed = _bullet.Speed;
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        _target = _player.GetComponentInChildren<Sensor>().SearchTarget();// 플레이어 sensor에서 감지된 타겟을 가져와야함.
        _targetPosition = _target.position;
        _playerPosition = _player.position;
        _rigidbody.velocity = (_targetPosition - _playerPosition).normalized * _speed;
    }

}