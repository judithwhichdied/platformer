using UnityEngine;

[RequireComponent (typeof(Animator))]
public class View : MonoBehaviour
{
    [SerializeField] private Sensor_Bandit _groundSensor;
    [SerializeField] private Attacker _attacker;

    private EnemyAttacker _enemyAttacker;

    private Animator _animator;
    private Player _player;
    private PlayerHealth _playerHealth;

    private const string AnimState = nameof(AnimState);
    private const string Hurt = nameof(Hurt);

    private const string AnimGrounded = "Grounded";
    private const string AnimJump = "Jump";
    private const string Attack = nameof(Attack);
    private const string Death = nameof(Death);

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
    }

    private void Update()
    {
        Rotate(_player.InputX);

        AnimateMove();

        AnimateJump();

        AnimateAttack();
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

    private void AnimateAttack()
    {
        if (_attacker.IsAttacked)
            _animator.SetTrigger(Attack);
    }

    private void AnimateTakingDamage()
    {
        if (_enemyAttacker.PlayerDamaged)
            _animator.SetTrigger(Hurt);
    }

    private void AnimateDeath()
    {
        if (_playerHealth.Health <= 0)
            _animator.SetTrigger(Death);
    }
}