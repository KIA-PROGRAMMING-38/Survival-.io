using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public EnemyManager EnemyManager { get; private set; }
    public ItemManager ItemManager { get; private set; }
    public PoolManager PoolManager { get; private set; }
    public TimeManager TimeManager { get; private set; }
    public StageManager StageManager { get; private set; }

    public static GameManager Instance;
    public Player Player;
    
    [SerializeField] private Text _timerText;
    public event Action OnGameEnded;
    private IEnumerator _processTimerCoroutine;
    
    // �Ʒ� �ð� ���� �κ��� stageManager�� �Ѿ ���߿� ���� �� �������� �κ�
    public float GameTime;
    public float MaxGameTime = 3 * 60f; // 3 minutes for each stage

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        CreateMangerObjects();
        Instance = this;

        // �ð� ���� �ڵ�� stageManager �Ǵ� �ٸ� ������ �Ѿ �κ�
        GameObject timerText = GameObject.Find("TimerText");
        Debug.Assert(timerText != null);
        _timerText = timerText.GetComponent<Text>();        
    }

    private void CreateMangerObjects()
    {
        GameObject gameObject;

        gameObject = new GameObject(nameof(TimeManager));
        gameObject.transform.parent = transform;
        TimeManager = gameObject.AddComponent<TimeManager>();
        TimeManager.GameManager = this;

        gameObject = new GameObject(nameof(StageManager));
        gameObject.transform.parent = transform;
        StageManager = gameObject.AddComponent<StageManager>();
        StageManager.GameManager = this;

        gameObject = new GameObject(nameof(PoolManager));
        gameObject.transform.parent = transform;
        PoolManager = gameObject.AddComponent<PoolManager>();
        PoolManager.GameManager = this;

        gameObject = new GameObject(nameof(EnemyManager));
        gameObject.transform.parent = transform;
        EnemyManager = gameObject.AddComponent<EnemyManager>();
        EnemyManager.GameManager = this;
        
        gameObject = new GameObject(nameof(ItemManager));
        gameObject.transform.parent = transform;
        ItemManager = gameObject.AddComponent<ItemManager>();
        ItemManager.GameManager = this;
    }

    private void Start()
    {        
        // �ð� ���� �ڵ�� stageManager�� �Ѿ �κ�
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
            GameTime = MaxGameTime; // MaxGameTime�� �ʰ��ϸ� ���� �ð��� �� �̻� �������� ����
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
