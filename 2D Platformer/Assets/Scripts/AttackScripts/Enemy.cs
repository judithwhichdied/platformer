using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Health))]
public class Enemy : MonoBehaviour
{
    private const string Hurt = nameof(Hurt);
    private const string Death = nameof(Death);

    private Animator _animator;
    private Health _enemyHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<Health>();
    }

    private void Update()
    {
        if ( _enemyHealth.CurrentHealth <= 0)
            Die();
    }

    private void Die()
    {
        _animator.SetTrigger(Death);
    }
}
