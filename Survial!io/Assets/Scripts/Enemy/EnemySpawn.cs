using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawn : MonoBehaviour
{
    private Transform[] _spawnPosition;    

    private void Awake()
    {
        _spawnPosition = GetComponentsInChildren<Transform>();
    }
    private float _timer;
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 0.7f)
        {
            _timer = 0f;
            Spawn();
        }
    }
    private void Spawn()
    {
        GameObject enemy = GameManager.Instance.Pool.Get(0);
        enemy.transform.position = _spawnPosition[Random.Range(1, _spawnPosition.Length)].position;        
    }

}
