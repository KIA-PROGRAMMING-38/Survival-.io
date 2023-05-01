using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // �� ģ���� �� ��. << �������� ���� ����
    // player ��ǥ
    // reposition �� �� �ʿ��� �κ� ����
    // ���� ������ ����
    private GameManager _gameManager;
    public GameManager GameManager
    {
        private get => _gameManager;
        set
        {
            _gameManager = value;            
        }
    }

    private Transform[] _spawnPoints;
    public Transform[] SpawnPoints
    {
        get => _spawnPoints;
        set => _spawnPoints = value;
    }
    private Transform[] _boxSpawnPoints;
    public Transform[] BoxSpawnPoints
    {
        get => _boxSpawnPoints;
        set => _boxSpawnPoints = value;
    }
        
}
