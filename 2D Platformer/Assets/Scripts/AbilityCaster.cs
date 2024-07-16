using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AbilityCaster : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerHealth _playerHealth;

    private SpriteRenderer _spriteRenderer;

    private bool _abilityEnabled = false;

    private int _stealingValue = 5;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _player.KeyPressed += CastAbility;
    }

    private void OnDisable()
    {
        _player.KeyPressed -= CastAbility;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy) && _abilityEnabled)
        {
            StartCoroutine(StealLife(enemy));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            StopCoroutine(StealLife(enemy));
        }
    }

    private void CastAbility()
    {
        if (_abilityEnabled == false)
        {
            _spriteRenderer.enabled = true;

            _abilityEnabled = true;

            StartCoroutine(nameof(StartCounting));
        }
    }

    private IEnumerator StartCounting()
    {
        float durability = 6f;

        float delay = 1f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (durability > 0)
        {
            yield return wait;

            durability--;
        }

        _abilityEnabled = false;

        _spriteRenderer.enabled = false;
    }

    private IEnumerator StealLife(EnemyHealth enemy)
    {
        float delay = 0.5f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (_abilityEnabled)
        {
            enemy.TakeDamage(_stealingValue);
            _playerHealth.TakeHealing(_stealingValue);

            yield return wait;
        }
    }
}