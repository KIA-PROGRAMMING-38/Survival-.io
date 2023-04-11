using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawn : MonoBehaviour
{
    private Transform[] _spawnPosition;
    private int _phase;
    
    private void Awake()
    {
        _spawnPosition = GetComponentsInChildren<Transform>();
    }
    
    private float _timer;
    private void Update()
    {
        _timer += Time.deltaTime;
        _phase = Mathf.FloorToInt(GameManager.Instance.GameTime / (GameManager.Instance.MaxGameTime / 3)); // 소수점을 버리고 게임 시작 이후 3단계의 페이즈 구성
        if (_timer > (_phase == 0 ? 0.7f : 0.3f)) // phase 0에서는 0.7초 간격으로 spawn, 그 이상에서는 0.3f 간격으로 spawn, phase 2는 향후 추가 개발
        {
            _timer = 0f;
            Debug.Log($"{_phase}");
            Spawn();
        }
    }

    private void Spawn()
    {
        // 각 position을 가지고 있는 부모 오브젝트의 좌표를 플레이어 좌표와 동일하게 하여 어느 위치에서나 동일한 범위 고정
        transform.position = GameManager.Instance.Player.transform.position; 

        GameObject enemy = GameManager.Instance.Pool.Get(_phase); // phase에 따라 몬스터 풀에서 가져올 몬스터가 달라짐
        enemy.transform.position = _spawnPosition[Random.Range(1, _spawnPosition.Length)].position;        
    }

}
