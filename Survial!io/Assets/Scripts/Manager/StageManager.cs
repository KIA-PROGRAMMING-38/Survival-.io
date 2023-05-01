using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // 이 친구가 할 일. << 스테이지 레벨 관리
    // player 좌표
    // reposition 할 때 필요한 부분 관리
    // 스폰 포지션 관리
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
