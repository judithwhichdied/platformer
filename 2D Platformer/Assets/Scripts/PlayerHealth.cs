using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _minHealth = 0;

    public int CurrentHealth { get; private set; } = 100;

    private void Update()
    {
        if (CurrentHealth <= 0)
            Die();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void TakeHealing(int healPoints)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + healPoints, _minHealth, _maxHealth);
    }

    private void Die()
    {
        float delay = 1.5f;

        Destroy(gameObject, delay);
    }
}