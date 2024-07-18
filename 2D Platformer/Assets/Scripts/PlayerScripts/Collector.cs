using UnityEngine;

public class Collector : MonoBehaviour
{
    private int _coinCount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
            _coinCount++;
        }
    }

    private void TakeCoin()
    {
        _coinCount++;
    }
}