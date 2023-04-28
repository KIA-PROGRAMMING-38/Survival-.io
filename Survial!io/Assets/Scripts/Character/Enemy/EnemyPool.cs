using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool
{
    public Enemy[] _enemyPrefab = new Enemy[1]; // test >> data에서 index 갯수 받아서 해당 개수만큼 prefab
    private int _enemyID;
    private EnemyData _enemyData;
    private ObjectPool<Enemy> _enemyPool;
        

    public void Init(int enemyID, Enemy enemyPrefab)
    {
        _enemyID = enemyID;
        _enemyPrefab[_enemyID] = enemyPrefab;        
        InitEnemyPool();
    }
 
    public Enemy GetEnemyFromPool() => _enemyPool.Get();

    private void InitEnemyPool() => _enemyPool = new ObjectPool<Enemy>(CreateEnemy,OnGetEnemyFromPool, OnReleaseEnemyToPool);        
    private Enemy CreateEnemy()
    {
        Enemy enemy = Object.Instantiate(_enemyPrefab[_enemyID]);
        enemy.Init(_enemyID, _enemyData);        
        return enemy;
    }  
    private void OnGetEnemyFromPool(Enemy enemy) => enemy.gameObject.SetActive(true);
    private void OnReleaseEnemyToPool(Enemy enemy) => enemy.gameObject.SetActive(false);
    
}

