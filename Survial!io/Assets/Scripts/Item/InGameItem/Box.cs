using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Item, IDamagable
{
    private Health _health;
    private ItemSpawn _itemSpawn;    
    public event Action<Box> OnTakeDamage;
    public event Action<Box> OnDead;


    private void Awake()
    {
        _health = GetComponentInChildren<Health>();
        _itemSpawn = GetComponentInChildren<ItemSpawn>();
    }
    private void Start()
    {
        OnDead -= _itemSpawn.SpawnInGameItem;
        OnDead += _itemSpawn.SpawnInGameItem;

        _health.OnDead -= Dead;
        _health.OnDead += Dead;
    }
    public override void Effect(Player player)
    {
        // Now, Box has no Effect for Player.
    }

    public void Dead()
    {
        OnDead?.Invoke(this);
    }

    public void TakeDamage(float damageAmount, GameObject attacker = null)
    {
        Dead();        
    }
}
