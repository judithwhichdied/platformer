using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public event Action CoinCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            CoinCollected?.Invoke();

            Destroy(gameObject);
        }
    }
}
