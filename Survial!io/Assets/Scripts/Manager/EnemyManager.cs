using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameManager _gameManager;
    private PoolManager _poolManager;
    private TimeManager _timeManager;
    private StageManager _stageManager;
    public GameManager GameManager
    {
        private get => _gameManager;
        set
        {
            _gameManager = value;
            _poolManager = GameManager.PoolManager;
            _timeManager = GameManager.TimeManager;
            _stageManager = GameManager.StageManager;            
        }
    }

    private protected EnemyData _enemyData;
    private Transform[] _spawnPosition; // take position from stage manager 
    private float _spawnInterval;

    // Stagemanger will have all datas about stage like positions

    private int _phase;
    /*
     1) When to Spawn : each stage has spawn inteval datas, on each intervals, invoke spawn event, with coroutine
     2) Where to Spawn : map - enemyspawnposition - spawnpositions << from stagemanager
     3) What to Spawn : Enemy prefabs from PoolManager
     4) How to Spawn : to Enemy Spawn, request Spawn. 
     */

    private void Update()
    {
        float testTimer = Time.deltaTime;
        float testInterval = 1f;
        if (testTimer >= testInterval) // 여기까지가 when 코루틴 대신 if문
        {
            testTimer = 0f;
            // invoke spawn event 대신 함수 직접 실행
        }
    }
   
}

