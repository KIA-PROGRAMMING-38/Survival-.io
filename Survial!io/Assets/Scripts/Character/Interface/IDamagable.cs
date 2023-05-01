using UnityEngine;
using System;
public interface IDamagable 
    // It needs 'Health' Component
    // It has enum type 'DamagableObject'
{
    void TakeDamage(float damageAmount, GameObject attacker = null);
    void Dead();
}

