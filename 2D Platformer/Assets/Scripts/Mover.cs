using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(Player))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 4.0f;
    [SerializeField] private Sensor_Bandit _groundSensor;

    private Player _player;
    private Rigidbody2D _body2D;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _body2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _body2D.velocity = new Vector2(_player.InputX * _speed, _body2D.velocity.y);

        if (_groundSensor.IsGrounded)
        {
            _body2D.gravityScale = 0;
        }
        else
        {
            _body2D.gravityScale = 1;
        }
    }
}