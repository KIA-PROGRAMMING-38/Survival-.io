using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    private int _maxHP;
    private float _currentHP;
    private Transform character;

    private void Start()
    {
        _maxHP = 1; // test value -> data 가져오도록 변경 필요
        _currentHP = _maxHP;
        character = transform.parent;        
    }
    
    private void Update()
    {
        Die();
    }

    public void TakeDamage(float damageAmount, GameObject attacker = null)
    {        
        _currentHP = _currentHP - damageAmount;
        
        if (_currentHP < 0)
        {
            _currentHP = 0;
        }
    }

    public void Die()
    {
        if (_currentHP <= 0) 
        { 
            character.gameObject.SetActive(false);            
        }
    }
}
