using UnityEngine;

[RequireComponent (typeof(Animator))]
public class View : MonoBehaviour
{
    [SerializeField] private Sensor_Bandit _groundSensor;

    private Animator _animator;
    private Player _player;

    private const string AnimState = nameof(AnimState);

    private const string AnimGrounded = "Grounded";
    private const string AnimJump = "Jump";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Rotate(_player.InputX);

        AnimateMove();

        AnimateJump();
    }

    private void Rotate(float velocityX)
    {
        float angleLeft = 0f;
        float angleRight = -180f;

        switch (velocityX)
        {
            case > 0:
                ChangeDirection(angleRight);
                break;

            case < 0:
                ChangeDirection(angleLeft);
                break;
        }
    }

    private void ChangeDirection(float angle)
    {
        Vector2 rotate = transform.localEulerAngles;
        rotate.y = angle;

        transform.localRotation = Quaternion.Euler(rotate);
    }

    private void AnimateJump()
    {
        if (_groundSensor.IsGrounded)
        {
            _animator.SetBool(AnimGrounded, _groundSensor.IsGrounded);
        }

        if (!_groundSensor.IsGrounded)
        {
            _animator.SetBool(AnimGrounded, _groundSensor.IsGrounded);
            _animator.SetTrigger(AnimJump);
        }
    }

    private void AnimateMove()
    {
        int runState = 2;
        int idleState = 0;

        if (Mathf.Abs(_player.InputX) > Mathf.Epsilon)
            _animator.SetInteger(AnimState, runState);
        else
            _animator.SetInteger(AnimState, idleState);
    }
}