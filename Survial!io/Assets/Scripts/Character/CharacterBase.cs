using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    protected CharacterStat baseStat = new CharacterStat();
    protected int currentHealth;
    protected float speed;
    protected const int DEFAULT_SPEED = 1; // ÀÓ½Ã °ª
    
    protected virtual void OnEnable()
    {
        currentHealth = baseStat.MaxHP;
        speed = baseStat.Speed * DEFAULT_SPEED;
    }

    public virtual void Move()
    {

    }

    public virtual void OnTakeDamage()
    {

    }

    public virtual void Died()
    {

    }
}
