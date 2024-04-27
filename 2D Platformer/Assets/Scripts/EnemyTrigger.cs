using System;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public event Action Triggered;

    public bool IsFound { get; private set; } = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            IsFound = true;
            Triggered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            IsFound = false;
    }
}
