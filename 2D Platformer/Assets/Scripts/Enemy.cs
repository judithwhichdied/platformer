using UnityEngine;

[RequireComponent(typeof(Animator), typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    private const string Hurt = nameof(Hurt);
    private const string Death = nameof(Death);

    private Animator _animator;
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
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
