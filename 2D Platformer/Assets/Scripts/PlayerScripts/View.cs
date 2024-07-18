using UnityEngine;

[RequireComponent (typeof(Animator), typeof(Player), typeof(Health))]
public class View : MonoBehaviour
{
    private const string AnimState = nameof(AnimState);
    private const string Hurt = nameof(Hurt);

    private const string AnimGrounded = "Grounded";
    private const string AnimJump = "Jump";
    private const string Attack = nameof(Attack);
    private const string Death = nameof(Death);

    [SerializeField] private Sensor_Bandit _groundSensor;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private EnemyAttacker _enemyAttacker;

    private Animator _animator;
    private Player _player;
    private Health _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Rotate(_player.InputX);

        AnimateMove();

        AnimateJump();

        AnimateAttack();

        AnimateDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyAttacker>(out EnemyAttacker enemyAttacker))
        {
            AnimateTakingDamage();
        }
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
        else
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
        if (_playerHealth.CurrentHealth <= 0)
            _animator.SetTrigger(Death);
    }
}