using System;
using UnityEngine;
using UnityEngine.Pool;

public
    class ItemSpawn : MonoBehaviour
{
    private Vector2 _spawnPosition;
    public Item _item;
    private ItemPool _itemPool;

    private void Awake()
    {
        _itemPool = GameManager.Instance.PoolManager.ItemPool;
    }

    public void SpawnExp(Enemy enemy)
    {
        EXP exp = (EXP)_itemPool.GetItemFromItemPool();
        Transform enemyTransform = enemy.transform.GetChild(0);
        _spawnPosition = enemyTransform.position;
        exp.transform.position = _spawnPosition;
    }
    private void SpawnInGameItem()
    {
        // 박스 및 InGameItem 기능 구현 시 추가 될 부분
    }
    private Item CreateItem()
    {
        Item item = Instantiate(_item);
        item.ItemPool = _itemPool.ItemPoolInstance;
        return item;
    }

    private void TakeItemFromPool(Item item) => item.gameObject.SetActive(true);
}
