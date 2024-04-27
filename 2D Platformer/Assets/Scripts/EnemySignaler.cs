using System;
using UnityEngine;

public class EnemySignaler : MonoBehaviour
{
    public event Action AttackPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            AttackPlayer?.Invoke();
        }
    }
}
