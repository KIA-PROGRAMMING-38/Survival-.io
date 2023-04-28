using UnityEngine;
using UnityEngine.Pool;

public abstract class Item : MonoBehaviour, IPickable
{
    protected Vector2 createPosition;
    protected Player player;
    public ObjectPool<Item> ItemPool { private get; set; }

    private void Awake()
    {
        ItemPool = GameManager.Instance.PoolManager.ItemPool.ItemPoolInstance;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 모든 아이템은 플레이어와 충돌 시 효과 발생
        {
            player = collision.GetComponent<Player>();
            Get();
            Effect(player);
            Release();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
    public void Get()
    {
        // 충돌시 뒤로 밀려났다가 플레이어 쪽을 향하는 연출 존재
        // 플레이어 좌표와 일치하는 순간 비활성화
    }
    public abstract void Effect(Player player);
    public void Release()
    {

        gameObject.SetActive(false);
        ItemPool.Release(this);
    }
}

