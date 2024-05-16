using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private int _healPoints = 50;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            _playerHealth.Heal(_healPoints);

            Destroy(gameObject);
        }
            
    }
}
