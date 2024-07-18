using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _minDamage = 0.1f;
    private float _maxDamage = 99.9f;

    public event Action Changed;

    public float MinHealth { get; protected set; } = 0;
    public float MaxHealth { get; protected set; } = 100;
    public float CurrentHealth { get; protected set; } = 100;

    public void TakeDamage(float damage)
    {
        CurrentHealth -= Mathf.Clamp(damage, _minDamage, _maxDamage);
        Changed?.Invoke();

        if (CurrentHealth <= 0)
            Die();
    }

    public void TakeHealing(float healPoints)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + healPoints, MinHealth, MaxHealth);
        Changed?.Invoke();
    }

    private void Die()
    {
        float delay = 1.5f;

        Destroy(gameObject, delay);
    }
}