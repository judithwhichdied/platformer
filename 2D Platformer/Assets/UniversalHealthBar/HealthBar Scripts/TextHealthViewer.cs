using TMPro;
using UnityEngine;

public class TextHealthViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _playerHealth;

    private void Awake()
    {
        ShowHealth();
    }
    private void OnEnable()
    {
        _playerHealth.Changed += ShowHealth;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= ShowHealth;
    }

    private void ShowHealth()
    {
        _text.text = $"Health: {_playerHealth.CurrentHealth} / {_playerHealth.MaxHealth}";
    }
}