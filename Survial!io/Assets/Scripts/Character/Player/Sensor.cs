using UnityEngine;

public class Sensor : MonoBehaviour
{
    private const float RANGE = 32;    
    private Transform _playerTransform;
    private Vector2 _center;
    private Collider2D[] _targets = new Collider2D[100];
    private Transform _targetTransform;
    private int _targetCount;
    private float _distance;
    private const float DEFAULT_DISTANCE = 64;
    private float _shortestDistance;

    private void Awake()
    {
        _playerTransform = transform;
        _center = _playerTransform.position;
    }

    public Transform SearchTarget()
    {        
        _targetCount = Physics2D.OverlapCircleNonAlloc(_center, RANGE, _targets, 1 << LayerMask.NameToLayer(LayerName.ENEMY));
        
        if (_targetCount == 0)
            return _playerTransform;

        _shortestDistance = DEFAULT_DISTANCE;
        
        foreach (Collider2D target in _targets)
        {
            if (target == null)
                break;

            _distance = Vector2.Distance(_playerTransform.position, target.transform.position);

            if (_shortestDistance > _distance)
            {
                _shortestDistance = _distance;
                _targetTransform = target.transform;
            }
        }

        return _targetTransform;
    }
}