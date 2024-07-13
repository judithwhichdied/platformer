using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDamager : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Button _button;

    public event Action<int> Damaged;

    private int _damage = 30;

    private void OnEnable()
    {
        _button.onClick.AddListener(ActivateEvent);
        Damaged += DealDamage;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ActivateEvent);
        Damaged -= DealDamage;
    }

    private void ActivateEvent()
    {
        Damaged?.Invoke(_damage);
    }

    private void DealDamage(int damage)
    {
        _playerHealth.TakeDamage(damage);
    }
}
