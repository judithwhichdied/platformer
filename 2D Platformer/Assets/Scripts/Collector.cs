using UnityEngine;

public class Collector : MonoBehaviour
{
    private int _coinCount;

    private Coin _coin;

    private void Awake()
    {
        _coin = GetComponent<Coin>();
    }

    private void OnEnable()
    {
        _coin.Collected += TakeCoin;
    }

    private void OnDisable()
    {
        _coin.Collected -= TakeCoin;
    }

    private void TakeCoin()
    {
        _coinCount++;
    }
}