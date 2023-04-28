using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : CharacterBase // ���� move �̻���� ����
{
    // Enemy�� Presenter �� Manager ����

    private Rigidbody2D _rigidbody;
    private Rigidbody2D _player;
    private Health _health;
    private ItemSpawn _itemSpawn;
    private Vector2 _targetPosition;
    public event Action<Enemy> OnTakeDamage;
    public event Action<Enemy> OnDead;
    private void Awake()
    {
        _player = GameManager.Instance.Player.GetComponent<Rigidbody2D>();
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
        _health = GetComponentInChildren<Health>();
        _itemSpawn = GetComponentInChildren<ItemSpawn>();
    }

    private void Start()
    {
        OnDead -= _itemSpawn.SpawnExp;
        OnDead += _itemSpawn.SpawnExp;

        _health.OnDead -= Dead;
        _health.OnDead += Dead;
    }
    private void Update()
    {
        Move();
    }

    public void Init(int id, EnemyData data)
    {

    }

    override public void Move()
    {
        // �׻� �÷��̾ ���Ѵ�.
        Direction = (_player.position - _rigidbody.position).normalized; // ChararcterBase���� ��� ���� �ʵ� 
    }

    override public void TakeDamage(float damageAmount, GameObject attacker = null)
    {
        // << Health : �ǰ� �޽��� ��
        // Spriter >> ���� �Ÿ��� ����
        // ��ƼŬ >> �� Ƣ��� ����
        // UI >> �÷��� ������ ���
        // �ִϸ��̼� >> �ְ� ����
    }

    override public void Dead()
    {

        // << Health : Die()
        // Animator >> ���� �ִϸ��̼����� ��ȯ
        // UI >> óġ�� ���� ī��Ʈ ����
        // ItemSpawn >> Enemy �Ѱ� �ѱ�� �ű⼭ ��ǥ �̰� ����
        
        OnDead?.Invoke(this);
        
    }
}
