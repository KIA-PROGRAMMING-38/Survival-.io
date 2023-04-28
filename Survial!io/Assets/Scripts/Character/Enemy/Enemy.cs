using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : CharacterBase // 현재 move 이상없이 동작
{
    // Enemy의 Presenter 및 Manager 역할

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
        // 항상 플레이어를 향한다.
        Direction = (_player.position - _rigidbody.position).normalized; // ChararcterBase에서 상속 받은 필드 
    }

    override public void TakeDamage(float damageAmount, GameObject attacker = null)
    {
        // << Health : 피격 메시지 줌
        // Spriter >> 깜빡 거리는 연출
        // 파티클 >> 피 튀기는 연출
        // UI >> 플로팅 데미지 출력
        // 애니메이션 >> 왜곡 연출
    }

    override public void Dead()
    {

        // << Health : Die()
        // Animator >> 죽음 애니메이션으로 전환
        // UI >> 처치한 몬스터 카운트 증가
        // ItemSpawn >> Enemy 넘겨 넘기면 거기서 좌표 뽑고 실행
        
        OnDead?.Invoke(this);
        
    }
}
