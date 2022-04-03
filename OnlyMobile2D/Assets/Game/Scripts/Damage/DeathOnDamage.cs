using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageable
{  
    public event Action OnDeath;
    public bool IsLive { get; private set; }
    public void TakeDamage(int damage)
    {
        Die();
    }
    private void Die() 
    {
        IsLive = false;
        OnDeath?.Invoke();
    }
}
