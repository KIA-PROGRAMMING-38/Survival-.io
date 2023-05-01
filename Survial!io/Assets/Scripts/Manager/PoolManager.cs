using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
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

    public EnemyPool EnemyPool;
    public Enemy TestPrefab;

    public ItemPool ItemPool;
    public Item ItemPrefab;

    public ItemPool EXPPool;
    public Item EXPPrefab;

    public ItemPool BoxPool;
    public Item BoxPrefab;
    private void Awake()
    {
        TestPrefab = Resources.Load<Enemy>("Prefab/Enemy");        
        EnemyPool = new EnemyPool();
        EnemyPool.Init(0,TestPrefab);

        EXPPrefab = Resources.Load<Item>("Prefab/EXP");
        EXPPool = new ItemPool();
        EXPPool.Init(EXPPrefab);

        BoxPrefab = Resources.Load<Item>("Prefab/Box");
        BoxPool = new ItemPool();
        BoxPool.Init(BoxPrefab);
    }


}
