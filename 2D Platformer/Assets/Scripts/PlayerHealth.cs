using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health { get; private set; } = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void Heal(int healPoints)
    {
        int maxHealth = 100;

        if (Health < maxHealth)
        {
            if ((Health + healPoints) > maxHealth)
            {
                Health = maxHealth;
            }
            else
            {
                Health += healPoints;
            }
        }

    }
}
