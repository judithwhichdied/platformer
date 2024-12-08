using UnityEngine;
using System.Collections;
using System;

public class AbilityCaster : MonoBehaviour
{
    [SerializeField] private Health _player;
    [SerializeField] private Player _input;

    private SpriteRenderer _renderer;

    private float _stealingValue = 10f;

    public event Action OnCoolDown;
    public event Action IsActive;

    private bool _coroutineActive = false;

    public bool AbilityOnCoolDown { get; private set; } = false;
    public bool CanActivate { get; private set; } = true;
    public float Duration { get; private set; } = 6f;
    public float CoolDown { get; private set; } = 4f;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();

        _renderer.enabled = false; 
    }

    private void OnEnable()
    {
        _input.AbilityCasted += CastAbility;
    }

    private void OnDisable()
    {
        _input.AbilityCasted -= CastAbility;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health enemy) && collision.gameObject.TryGetComponent(out Enemy _) && _renderer.enabled)
        {
            StartCoroutine(StealLife(enemy));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health enemy) && collision.gameObject.TryGetComponent(out Enemy _) && _renderer.enabled)
        {
            StopCoroutine(StealLife(enemy));
        }
    }

    private void CastAbility()
    {
        if (AbilityOnCoolDown == false && CanActivate)
        {
            _renderer.enabled = true;

            CanActivate = false;

            StartCoroutine(StartCounting());
        }
    }

    private IEnumerator StealLife(Health enemy)
    {
        if (_coroutineActive)
            yield break;

        _coroutineActive = true;

        float delay = 1f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        if (enemy.CurrentHealth > 0)
        {
            enemy.TakeDamage(_stealingValue);
            _player.TakeHealing(_stealingValue);
        }

        yield return wait;

        _coroutineActive = false;
    }

    private IEnumerator StartCounting()
    {
        IsActive?.Invoke();

        yield return new WaitForSecondsRealtime(Duration);

        AbilityOnCoolDown = true;
        OnCoolDown?.Invoke();

        _renderer.enabled = false;

        yield return new WaitForSecondsRealtime(CoolDown);

        AbilityOnCoolDown = false;
        CanActivate = true;
    }   
}