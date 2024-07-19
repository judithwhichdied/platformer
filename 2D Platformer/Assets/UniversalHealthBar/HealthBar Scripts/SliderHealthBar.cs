using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected Slider _bar;

    protected virtual void Start()
    {
        _bar.value = _health.CurrentHealth / _health.MaxHealth;
    }

    protected virtual void OnEnable()
    {
        _health.Changed += FillBar;
    }

    protected virtual void OnDisable()
    {
        _health.Changed -= FillBar;
    }

    protected virtual void FillBar()
    {
        float filledArea = _health.CurrentHealth / _health.MaxHealth;

        _bar.value = filledArea;
    }
}
