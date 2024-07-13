using UnityEngine;

public class SmoothHealthBar : SliderHealthBar
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();  
    }

    protected override void OnEnable()
    {
        HealthChanged += Fill;
    }

    protected override void OnDisable()
    {
        HealthChanged -= Fill;
    }

    private void Fill()
    {
        float step = _bar.maxValue / 2;

        _bar.value = Mathf.MoveTowards(_bar.value, _health.CurrentHealth, step * Time.deltaTime);
    }
}
