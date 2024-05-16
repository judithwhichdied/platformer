using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private const string Hurt = nameof(Hurt);
    private const string Death = nameof(Death);

    private Animator _animator;

    public int Health { get; private set; } = 100;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if ( Health <= 0)
            Die();
    }

    private void Die()
    {
        float delay = 1.5f;

        _animator.SetTrigger(Death);

        Destroy(gameObject, delay);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        _animator.SetTrigger(Hurt);
    }
}
