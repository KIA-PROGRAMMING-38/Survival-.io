using UnityEngine;

public class Sensor : MonoBehaviour
{
    private const float RANGE = 100;    
    private Transform _playerTransform;
    private Vector2 _center;
    private Collider2D[] _targets = new Collider2D[100];
    private Transform _targetTransform;
    private int _targetCount;
    private int _randomIndex;

    private void Awake()
    {
        _playerTransform = transform;
        _center = _playerTransform.position;
    }


    public Transform SearchTarget()
    {
        _targetCount = Physics2D.OverlapCircleNonAlloc(_center, RANGE, _targets, 1 << LayerMask.NameToLayer(LayerName.ENEMY));
        if (_targetCount == 0)
            return null;
        _randomIndex = Random.Range(0, _targetCount);
        _targetTransform = _targets[_randomIndex].GetComponent<Transform>();        
        return _targetTransform;
    }
}