using System.Collections;
using UnityEngine;

public class SmoothHealthBar : SliderHealthBar
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void FillBar()
    {
        StartCoroutine(SmoothChanging());
    }

    private IEnumerator SmoothChanging()
    {
        float step = _bar.maxValue;
        float delay = 0.01f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (_bar.value != _health.CurrentHealth)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, _health.CurrentHealth, step * Time.deltaTime);

            yield return wait;
        }
    }
}
