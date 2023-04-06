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
        // 각 position을 가지고 있는 부모 오브젝트의 좌표를 플레이어 좌표와 동일하게 하여 어느 위치에서나 동일한 범위 고정
        transform.position = GameManager.Instance.Player.transform.position; 

        GameObject enemy = GameManager.Instance.Pool.Get(0);
        enemy.transform.position = _spawnPosition[Random.Range(1, _spawnPosition.Length)].position;        
    }

}
