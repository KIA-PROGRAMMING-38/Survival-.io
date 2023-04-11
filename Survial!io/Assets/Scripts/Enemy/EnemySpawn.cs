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
        _phase = Mathf.FloorToInt(GameManager.Instance.GameTime / (GameManager.Instance.MaxGameTime / 3)); // �Ҽ����� ������ ���� ���� ���� 3�ܰ��� ������ ����
        if (_timer > (_phase == 0 ? 0.7f : 0.3f)) // phase 0������ 0.7�� �������� spawn, �� �̻󿡼��� 0.3f �������� spawn, phase 2�� ���� �߰� ����
        {
            _timer = 0f;
            Debug.Log($"{_phase}");
            Spawn();
        }
    }

    private void Spawn()
    {
        // �� position�� ������ �ִ� �θ� ������Ʈ�� ��ǥ�� �÷��̾� ��ǥ�� �����ϰ� �Ͽ� ��� ��ġ������ ������ ���� ����
        transform.position = GameManager.Instance.Player.transform.position; 

        GameObject enemy = GameManager.Instance.Pool.Get(_phase); // phase�� ���� ���� Ǯ���� ������ ���Ͱ� �޶���
        enemy.transform.position = _spawnPosition[Random.Range(1, _spawnPosition.Length)].position;        
    }

}
