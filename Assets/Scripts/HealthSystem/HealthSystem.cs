using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

public event System.Action OnHealthDepleted;
public event System.Action<int> OnHealthChanged;
[SerializeField] private int _hpAmountTotal;

private int _currentHp;

public int CurrentHp {get{return _currentHp;}}

private void Awake() 
{
    ResetHP();
}

public void ResetHP()
{
    _currentHp = _hpAmountTotal;    
    OnHealthChanged?.Invoke(_currentHp);

}
public void TakeHit(int damage)
{
    _currentHp -= damage;

    OnHealthChanged?.Invoke(_currentHp);

    if (_currentHp <= 0)
    {
        Die();        
    }
}

public void Heal(int hp)
{
    int previousHP = _currentHp;

    _currentHp += hp;

    if (_currentHp > _hpAmountTotal)
    {
        _currentHp = _hpAmountTotal;
    }

    OnHealthChanged?.Invoke(_currentHp);
}
private void Die()
{
    OnHealthDepleted?.Invoke();
}

}
