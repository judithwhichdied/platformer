using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private Health _player;

    private int _healPoints = 50;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health player))
        {
            _player.TakeHealing(_healPoints);

            Destroy(gameObject);
        }    
    }
}
