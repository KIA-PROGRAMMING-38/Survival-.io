using UnityEngine;
using UnityEngine.Pool;

public class ItemPool
{
    public ObjectPool<Item> ItemPoolInstance;    
    public Item _itemPrefab;
    // ItemData class 필요

    public void Init(Item ItemPrefab)
    {
        _itemPrefab = ItemPrefab;
        ItemPoolInstance = new ObjectPool<Item>(CreateItem, TakeItemFromPool);
    }

    public Item GetItemFromItemPool() => ItemPoolInstance.Get();
    private Item CreateItem()
    {
        Item item = Object.Instantiate(_itemPrefab);
        item.ItemPool = ItemPoolInstance;
        return item;
    }

    private void TakeItemFromPool(Item item) => item.gameObject.SetActive(true);

}
