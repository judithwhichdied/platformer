using System.Collections;
using UnityEngine;

public class SmoothHealthBar : SliderHealthBar
{
    protected override void FillBar()
    {
        StartCoroutine(SmoothChanging());
    }

    private IEnumerator SmoothChanging()
    {
        float step = _bar.maxValue;

        while (_bar.value != _health.CurrentHealth)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, _health.CurrentHealth / _health.MaxHealth, step * Time.deltaTime);

            yield return null;
        }
    }
}