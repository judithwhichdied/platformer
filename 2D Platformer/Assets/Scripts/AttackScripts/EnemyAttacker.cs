using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    private const string Attack = "Attack";
    private const string Hitbox = nameof(Hitbox);

    [SerializeField] private EnemySignaler _signaler;
    [SerializeField] private Animator _animator;

    private BoxCollider2D _hitBox;
    private float _delayActivation = 0.4f;
    private float _delayDeactivation = 0.6f;
    private int _enemyDamage = 60;

    public bool PlayerDamaged { get; private set; } = false;

    private void Awake()
    {
        _hitBox = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        _signaler.AttackPlayer += Prepare;
    }

    private void OnDisable()
    {
        _signaler.AttackPlayer -= Prepare;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent <Health>(out Health player))
        {
            DealDamage(player);
            PlayerDamaged = true;
        }
        else
        {
            PlayerDamaged = false;
        }
    }

    private void Prepare()
    {
        _animator.SetTrigger(Attack);

        StartCoroutine(nameof(ActivateHitbox));
        StartCoroutine(nameof(DeactivateHitbox));
    }

    private void DealDamage(Health player)
    {
        player.TakeDamage(_enemyDamage);
    }

    private IEnumerator ActivateHitbox()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayActivation);

        yield return wait;

        _hitBox.enabled = true;
    }

    private IEnumerator DeactivateHitbox()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayDeactivation);

        yield return wait;

        _hitBox.enabled = false;
    }
}