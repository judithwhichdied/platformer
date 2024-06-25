using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class Attacker : MonoBehaviour
{
    private BoxCollider2D _hitBox;

    public bool IsAttacked { get; private set; }

    private bool _canAttack = true;

    private float _delayActivation = 0.4f;
    private float _delayDeactivation = 0.6f;
    private float _attackCooldown = 1f;

    private int _playerDamage = 10;

    private void Awake()
    {
        _hitBox = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canAttack)
        {
            IsAttacked = true;
            Invoke(nameof(ActivateHitBox), _delayActivation);
            Invoke(nameof(DeactivateHitBox), _delayDeactivation);

            _canAttack = false;
            Invoke(nameof(StopAttack), _attackCooldown);
        }
        else
        {
            IsAttacked = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Attack(enemy);
        }
    }

    private void ActivateHitBox()
    {
        _hitBox.enabled = true;
    }

    private void DeactivateHitBox()
    {
        _hitBox.enabled = false;
    }

    private void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_playerDamage);
    }

    private void StopAttack()
    {
        _canAttack = true;
    }
}