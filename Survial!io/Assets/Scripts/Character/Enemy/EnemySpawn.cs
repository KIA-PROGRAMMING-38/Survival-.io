using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawn : MonoBehaviour
// EnemySpawnPoints�� ������Ʈ, �ڽ� ������Ʈ���� position�� ������ point
{    
    private EnemyManager _enemyManager;
    public EnemyManager EnemyManager
    {
        private get => _enemyManager;
        set => _enemyManager = value;
    }
    
    private int _phase;
    private float _currentGameTime;
    private float _currentWaveTime;
    private float _phaseTime;
    private Vector2 _player;
    private Transform _spawnPositionCenter;
    private Vector2 _spawnPosition;
    private int _inRandomIndex;
    private IEnumerator _spawnCoroutine;
    private WaitForSeconds _waitForSpawnTime;    
    private Transform[] _spawnPoints;

    private void Start()
    {
        _phaseTime = 60f;
        _currentWaveTime = 0;
        _waitForSpawnTime = new WaitForSeconds(1); // test        
        _spawnPoints = GetComponentsInChildren<Transform>();
        GameManager.Instance.StageManager.SpawnPoints = _spawnPoints;
        _spawnPositionCenter = GetComponent<Transform>();
    }
    private void Update()
    {
        _player = GameManager.Instance.Player.GetComponent<Transform>().position;
        _spawnPositionCenter.position = _player;
        EnemyPool TestEnemyPool = GameManager.Instance.PoolManager.EnemyPool; // test       
        _spawnCoroutine = Spawn(_spawnPoints, TestEnemyPool);
        if (_currentWaveTime == 0)
        {
            StartCoroutine(_spawnCoroutine);
        }
        _currentWaveTime += Time.deltaTime;
    }

    private IEnumerator Spawn(Transform[] spawnPositions, EnemyPool enemyPool)
    {
        while (_currentWaveTime < _phaseTime)
        {
            Enemy enemyInstance = enemyPool.GetEnemyFromPool(); // phase ���� �ٸ� �ν��Ͻ� �̾ƾ���
            _inRandomIndex = UnityEngine.Random.Range(0, spawnPositions.Length);
            _spawnPosition = spawnPositions[_inRandomIndex].position;
            enemyInstance.transform.position = _spawnPosition;

            yield return _waitForSpawnTime;
        }
        StopCoroutine(_spawnCoroutine);
        
    }
}
