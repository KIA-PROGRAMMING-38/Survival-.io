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

    private void Awake()
    {
        TestPrefab = Resources.Load<Enemy>("Prefab/Enemy");
        EnemyPool = new EnemyPool();
        EnemyPool.Init(0,TestPrefab);

        ItemPrefab = Resources.Load<Item>("Prefab/Item");
        ItemPool = new ItemPool();
        ItemPool.Init(ItemPrefab);
    }


}
