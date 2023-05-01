using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    private Vector2 _spawnPosition;
    private Transform _spawnTransform;
    private Transform[] _boxSpawnPoints;
    private ItemPool _boxPool;
    private IEnumerator _spawnCoroutine;
    private WaitForSeconds _waitForSpawnTime;
    private bool[] _isOccupied;
    private int _boxCount;
    private int _maxBoxCount;
    private const int _exceptParentObject = 1; // Random 범위에서 0이 들어가면 parent Object, 이를 제외하기 위한 상수
    private const int _boxSpawnInterval = 10;

    private void Start()
    {
        _boxPool = GameManager.Instance.PoolManager.BoxPool;
        _boxSpawnPoints = GetComponentsInChildren<Transform>();
        _maxBoxCount = _boxSpawnPoints.Length;
        GameManager.Instance.StageManager.BoxSpawnPoints = _boxSpawnPoints;
        _isOccupied = new bool[_maxBoxCount];
        _waitForSpawnTime = new WaitForSeconds(_boxSpawnInterval);
        _spawnCoroutine = SpawnCoroutine();
        StartCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnBox();
            yield return _waitForSpawnTime;
        }
        
    }

    private int _inRandomIndex;
    private void SpawnBox()
    {
        if (_boxCount == _maxBoxCount - _exceptParentObject)
        {
            StopCoroutine(_spawnCoroutine);
            return;
        }

        while (_boxCount < _maxBoxCount)
        {
            
            _inRandomIndex = UnityEngine.Random.Range(_exceptParentObject, _maxBoxCount);            
            if (_isOccupied[_inRandomIndex]) continue;

            _spawnTransform = _boxSpawnPoints[_inRandomIndex];
            _spawnPosition = _spawnTransform.position;
            Box box = (Box)_boxPool.GetItemFromItemPool();
            box.transform.parent = _spawnTransform;            
            box.transform.position = _spawnPosition;
            
            _isOccupied[_inRandomIndex] = true;
            ++_boxCount;            

            break;
        }

    }
}
