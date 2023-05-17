using Unity.VisualScripting;
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
    private Vector2 _direction;
    private Bullet _bullet;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GameManager.Instance.Player.transform;
        _bullet = GetComponent<Bullet>();
        _speed = _bullet.Speed;
    }
    private void OnEnable()
    {
        Move();
    }

    public void Move()
    {
        _target = _player.GetComponentInChildren<Sensor>().SearchTarget();// 플레이어 sensor에서 감지된 타겟을 가져와야함.
          
        _targetPosition = _target.position;        
        _playerPosition = _player.position;

        _direction = (_targetPosition - _playerPosition).normalized;
        Debug.Log(_direction);
        
        if (_direction == Vector2.zero)
            _direction = Vector2.up;
        _rigidbody.velocity = _direction * _speed;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, _direction);
    }

}