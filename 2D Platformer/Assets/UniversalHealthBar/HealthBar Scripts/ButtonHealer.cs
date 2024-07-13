using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHealer : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Button _button;

    public event Action<int> Healed;

    private int _healPoints = 10;

    private void OnEnable()
    {
        _button.onClick.AddListener(ActivateEvent);
        Healed += Heal;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ActivateEvent);
        Healed -= Heal;
    }

    private void ActivateEvent()
    {
        Healed?.Invoke(_healPoints);
    }

    private void Heal(int healPoints)
    {
        _playerHealth.TakeHealing(healPoints);
    }
}
