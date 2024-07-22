using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private Health _player;
    [SerializeField] private Collector _collector;

    private float _healPoints = 50f;

    private void OnEnable()
    {
        _collector.HealTaked += Heal;
    }

    private void OnDisable()
    {
        _collector.HealTaked -= Heal; 
    }

    private void Heal()
    {
        _player.TakeHealing(_healPoints);
    }
}