using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public event Action Collected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Collected?.Invoke();

            Destroy(gameObject);
        }
    }
}