using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Jumper : MonoBehaviour
{
    private const string GroundSensorName = "GroundSensor";
    private const string PlayerName = "Player";
    private const string ColliderName = "Ground";

    [SerializeField] private float _jumpForce = 6.0f;

    private Sensor_Bandit _groundSensor;

    private Rigidbody2D _player;

    private int _playerObject, _collideObject;

    private void Awake()
    {
        _player = GetComponent<Rigidbody2D>();

        _groundSensor = transform.Find(GroundSensorName).GetComponent<Sensor_Bandit>();

        _playerObject = LayerMask.NameToLayer(PlayerName);
        _collideObject = LayerMask.NameToLayer(ColliderName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundSensor.IsGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (_player.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(_playerObject, _collideObject, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(_playerObject, _collideObject, false);
        }
    }

    private void Jump()
    {
        _player.velocity = new Vector2(_player.velocity.x, _jumpForce);
    }
}