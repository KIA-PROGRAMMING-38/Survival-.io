using UnityEngine;
using System;
public interface IDamagable 
    // It needs 'Health' Component
    // It has enum type 'DamagableObject'
{
    public event Action<DamagableObject> OnTakeDamage;
    public event Action<DamagableObject> OnDead;

    void TakeDamage(float damageAmount, GameObject attacker = null);
    void Dead();
}

