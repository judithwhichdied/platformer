using UnityEngine;

public class Health : MonoBehaviour
{
    public int MinHealth { get; protected set; } = 0;
    public int MaxHealth { get; protected set; } = 100;
    public int CurrentHealth { get; protected set; } = 100;

    protected virtual void Update()
    {
        if (CurrentHealth <= 0)
            Die();
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public virtual void TakeHealing(int healPoints)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + healPoints, MinHealth, MaxHealth);
    }

    protected virtual void Die()
    {
        float delay = 1.5f;

        Destroy(gameObject, delay);
    }
}