using System;
using UnityEngine;
using UnityEngine.Pool;

public
    class ItemSpawn : MonoBehaviour
{
    private Vector2 _spawnPosition;   
    public Item _item;
    private ItemPool _itemPool;
    private ItemPool _expPool;    

    private void Start()
    {
        _itemPool = GameManager.Instance.PoolManager.ItemPool;
        _expPool = GameManager.Instance.PoolManager.EXPPool;     
    }

    private void Update()
    {        

    }

    public void SpawnExp(Enemy enemy)
    {
        EXP exp = (EXP)_expPool.GetItemFromItemPool();        
        Transform enemyTransform = enemy.transform.GetChild(0);
        _spawnPosition = enemyTransform.position;
        exp.transform.position = _spawnPosition;
    }
    
    public void SpawnInGameItem(Box box)
    {
        Debug.Log("item");
    }    
}
