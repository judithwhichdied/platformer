using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    private const string Attack = "Attack";

    [SerializeField] private EnemySignaler _signaler;
    [SerializeField] private Animator _animator;

    private BoxCollider2D _hitBox;

    private const string Hitbox = nameof(Hitbox);

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
        if (collision.gameObject.TryGetComponent <PlayerHealth>(out PlayerHealth player))
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

        Invoke(nameof(ActivateHitBox), _delayActivation);
        Invoke(nameof(DeactivateHitBox), _delayDeactivation);
    }

    private void DealDamage(PlayerHealth player)
    {
        player.TakeDamage(_enemyDamage);
    }

    private void ActivateHitBox()
    {
        _hitBox.enabled = true;
    }

    private void DeactivateHitBox()
    {
        _hitBox.enabled = false;
    }
}
