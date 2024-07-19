using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Changed;

    public float MinHealth { get; protected set; } = 0;
    public float MaxHealth { get; protected set; } = 100;
    public float CurrentHealth { get; protected set; } = 100;

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, MinHealth, MaxHealth);           
            Changed?.Invoke();

            if (CurrentHealth <= 0)
                Die();
        }
    }

    public void TakeHealing(float healPoints)
    {
        if (healPoints >= 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + healPoints, MinHealth, MaxHealth);
            Changed?.Invoke();
        }
    }

    private void Die()
    {
        float delay = 1.5f;

        Destroy(gameObject, delay);
    }
}