using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    public event Action OnGameEnded;
    private IEnumerator _processTimerCoroutine;

    public static GameManager Instance;
    public PlayerMovement Player;
    public PoolManager Pool;
    public float GameTime;
    public float MaxGameTime = 3 * 60f; // 3 minutes for each stage

    private void Awake()
    {
        GameObject timerText = GameObject.Find("TimerText");
        Debug.Assert(timerText != null);
        _timerText = timerText.GetComponent<Text>();
        
        Instance = this;
    }

    private void Start()
    {
        TimerModel.OnElapseTime -= ShowTime;
        TimerModel.OnElapseTime += ShowTime;

        OnGameEnded += () => StopCoroutine(_processTimerCoroutine);

        _processTimerCoroutine = ProcessTimer();
        StartCoroutine(_processTimerCoroutine);

        TimerModel.ElapsedTime = 0;
    }
    private void Update()
    {
        GameTime += Time.deltaTime;
        
        if (GameTime > MaxGameTime)
        {
            GameTime = MaxGameTime; // MaxGameTime을 초과하면 게임 시간이 더 이상 증가하지 않음
        }
        
    }

    private void ShowTime()
    {
        int second = (int)TimerModel.ElapsedTime % 60;
        int minute = (int)TimerModel.ElapsedTime / 60;
        _timerText.text = $"{minute:D2}:{second:D2}";
    }

    private IEnumerator ProcessTimer()
    {
        while(true)
        {
            TimerModel.ElapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
