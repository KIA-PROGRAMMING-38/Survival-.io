using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerMovement Player;
    public PoolManager Pool;
    public float GameTime;
    public float MaxGameTime = 3 * 60f; // 3 minutes for each stage

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        GameTime += Time.deltaTime;
        
        if (GameTime > MaxGameTime)
        {
            GameTime = MaxGameTime; // MaxGameTime�� �ʰ��ϸ� ���� �ð��� �� �̻� �������� ����
        }
        
    }
}
