using TMPro;
using UnityEngine;

public class TextHealthViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _playerHealth;

    private void Update()
    {
        _text.text = $"Health: {_playerHealth.CurrentHealth} / {_playerHealth.MaxHealth}";
    }
}