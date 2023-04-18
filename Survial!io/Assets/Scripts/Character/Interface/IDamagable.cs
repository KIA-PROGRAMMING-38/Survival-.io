using UnityEngine;
public interface IDamagable
{
    void TakeDamage(float damageAmount, GameObject attacker = null);
}

