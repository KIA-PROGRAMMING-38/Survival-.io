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
        _maxHP = 1; // test value -> data ���������� ���� �ʿ�
        _currentHP = _maxHP;
        _Ibase = GetComponent<IDamagable>();
    }

    public void TakeDamage(float damageAmount, GameObject attacker = null)
    {
        _currentHP -= damageAmount;        

        // ���ʹ� ������ ������ ���� �Ÿ��� ����
        // �÷��̾�� ������ ������ ��Ƣ��� ����        
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

        // ���� ������Ʈ - ���� ���
        // 1. �÷��̾� - ���� ���� UI
        // 2. ���� - ������ ���� - ����ġ ����
        // 3. �ڽ� - ������ ���� - �ΰ��� ������ ����
    }
}
