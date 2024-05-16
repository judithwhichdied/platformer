using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class Attacker : MonoBehaviour
{
    private const string Hitbox = nameof(Hitbox);

    private BoxCollider2D _hitBox;

    public bool IsAttacked { get; private set; }

    private float _delayActivation = 0.4f;
    private float _delayDeactivation = 0.6f;

    private int _playerDamage = 10;

    private void Awake()
    {
        _hitBox = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsAttacked = true;
            Invoke(nameof(ActivateHitBox), _delayActivation);
            Invoke(nameof(DeactivateHitBox), _delayDeactivation);
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
}