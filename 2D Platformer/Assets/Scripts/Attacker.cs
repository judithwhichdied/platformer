using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class Attacker : MonoBehaviour
{
    private BoxCollider2D _hitBox;

    private bool _canAttack = true;

    private float _delayActivation = 0.4f;
    private float _delayDeactivation = 0.6f;
    private float _attackCooldown = 1f;

    private int _playerDamage = 10;

    private KeyCode _leftMouseButton = KeyCode.Mouse0;

    public bool IsAttacked { get; private set; }

    private void Awake()
    {
        _hitBox = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_leftMouseButton) && _canAttack)
        {
            IsAttacked = true;
            StartCoroutine(nameof(ActivateHitbox));
            StartCoroutine(nameof(DeactivateHitbox));

            _canAttack = false;
            StartCoroutine(nameof(StopAttacking));
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

    private void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_playerDamage);
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

    private IEnumerator StopAttacking()
    {
        WaitForSeconds wait = new WaitForSeconds(_attackCooldown);

        yield return wait;

        _canAttack = true;
    }
}