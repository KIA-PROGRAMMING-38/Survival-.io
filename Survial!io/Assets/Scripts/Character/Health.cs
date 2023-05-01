using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxHP;
    private float _currentHP;
    private IDamagable _Ibase;
    private GameObject _baseObject;

    public event Action OnDead;

    private void Awake()
    {
        _baseObject = transform.parent.gameObject;        
    }

    private void Start()
    {
        _maxHP = 1; // test value -> data 가져오도록 변경 필요
        _currentHP = _maxHP;
        _Ibase = GetComponent<IDamagable>();
    }

    public void TakeDamage(float damageAmount, GameObject attacker = null)
    {
        _currentHP -= damageAmount;        

        // 몬스터는 데미지 입으면 깜빡 거리는 연출
        // 플레이어는 데미지 입으면 피튀기는 연출        
        if (_currentHP <= 0)
        {
            _currentHP = 0;
            Die();
        }
    }

    public void Die()
    {
        _baseObject.SetActive(false);        
        OnDead?.Invoke();

        // 죽은 오브젝트 - 구독 대상
        // 1. 플레이어 - 게임 종료 UI
        // 2. 몬스터 - 아이템 스폰 - 경험치 스폰
        // 3. 박스 - 아이템 스폰 - 인게임 아이템 스폰
    }
}
