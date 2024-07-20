using TMPro;
using UnityEngine;

public class TextHealthViewer : SliderHealthBar
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        FillBar();
    }
    
    protected override void FillBar()
    {
        _text.text = $"Health: {_health.CurrentHealth} / {_health.MaxHealth}";
    }
}