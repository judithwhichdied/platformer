using UnityEngine;
using System.Collections;
using TMPro;

public class AbilityCaster : MonoBehaviour
{
    [SerializeField] private Health _player;
    [SerializeField] private Player _input;
    [SerializeField] private TextMeshProUGUI _cooldownView;

    private float _duration = 6f;
    private float _stealingValue = 0.2f;

    private bool _isActive = false;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _input.KeyPressed -= CastAbility;
    }

    private void OnDisable()
    {
        _input.KeyPressed += CastAbility;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isActive)
        {
            if (collision.gameObject.TryGetComponent(out Health enemy) && collision.gameObject.TryGetComponent(out Enemy en))
            {
                StealLife(enemy);

                
            }
        }
    }

    private void CastAbility()
    {
        gameObject.SetActive(true);

        if (_isActive == false)
        {
            StartCoroutine(StartCounting());
        }
    }

    private void StealLife(Health enemy)
    {
        enemy.TakeDamage(_stealingValue);
        _player.TakeHealing(_stealingValue);
    }

    private IEnumerator StartCounting()
    {
        float delay = 1f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        _isActive = true;

        for (float i = _duration; i > 0; i--)
        {
            _cooldownView.text = $"{i}";

            yield return wait;
        }

        _isActive = false;
        gameObject.SetActive(false);
    }
}