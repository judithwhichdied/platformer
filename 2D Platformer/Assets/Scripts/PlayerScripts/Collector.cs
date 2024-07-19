using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Collector : MonoBehaviour
{
    private int _coinCount;

    public event Action HealTaked;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
            _coinCount++;
        }

        if (collision.gameObject.TryGetComponent(out Healer healer))
        {
            HealTaked?.Invoke();
            Destroy(healer.gameObject);
        }
    }

    private void TakeCoin()
    {
        _coinCount++;
    }
}