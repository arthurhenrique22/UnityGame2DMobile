using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    private int damege = 10;

    private void OnTriggerEnter2D(Collider2D collission) 
    {
        IDamageable damageable = collission.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damege);
        }
    }
}
