using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IDamagable, IMovable
    // It is 'Player' or 'Enemy'.
{
    protected CharacterStat baseStat = new CharacterStat();    
    protected int currentHealth;
    protected const int DEFAULT_SPEED = 1;

    public Vector2 Direction { get; set; }
    public float Speed { get; set; }

    protected virtual void OnEnable()
    {
        currentHealth = baseStat.MaxHP;
        Speed = baseStat.Speed * DEFAULT_SPEED;        
    }
    
    public abstract void Move();
    public abstract void TakeDamage(float damageAmount, GameObject attacker = null);
    public abstract void Dead();
}
