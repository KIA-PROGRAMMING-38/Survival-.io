using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private GameManager _gameManager;
    public GameManager GameManager
    {
        private get => _gameManager;
        set
        {
            _gameManager = value;            
        }
    }

    private float _currentGameTime; // 게임이 끝날 때까지 현재 시간 체크
                                                     
    public const float MAX_GAME_TIME = 3 * 60f; // 3 minutes for each stage

    private float _timer;
    private int _phase;
    private const int PHASE_COUNT = 3;
    //private void Update()
    //{
    //    _timer += Time.deltaTime;
    //    _phase = Mathf.FloorToInt(_currentGameTime / (MAX_GAME_TIME / PHASE_COUNT)); // 소수점을 버리고 게임 시작 이후 3단계의 페이즈 구성
    //}
}
