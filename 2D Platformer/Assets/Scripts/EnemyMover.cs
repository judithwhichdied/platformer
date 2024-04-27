using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMover : MonoBehaviour
{
    private const string AnimState = nameof(AnimState);

    [SerializeField] private Transform _waypointPrefab;
    [SerializeField] private EnemyTrigger _trigger;
    [SerializeField] private Player _player;

    private Animator _animator;
    private Enemy _enemy;

    private List<Vector3> _waypoints = new List<Vector3>();

    private int _currentWaypoint = 0;
    private int _positionXScale = 5;

    private float _speed = 3f;

    private Vector3 _waypoint1Position;
    private Vector3 _waypoint2Position;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();

        _waypoint1Position = new Vector3(transform.position.x + _positionXScale, transform.position.y);
        _waypoint2Position = new Vector3(transform.position.x - _positionXScale, transform.position.y);

        _waypoints.Add(_waypoint1Position);
        _waypoints.Add(_waypoint2Position);
    }

    private void Start()
    {
        Instantiate(_waypointPrefab, _waypoint1Position, Quaternion.identity);
        Instantiate(_waypointPrefab, _waypoint2Position, Quaternion.identity);
    }

    private void Update()
    {
        if (_enemy.Health > 0 && !_trigger.IsFound)
        {
            Patrol();
        }
    }

    private void OnEnable()
    {
        _trigger.Triggered += Chase;
    }

    private void OnDisable()
    {
        _trigger.Triggered -= Chase;
    }

    private void Patrol()
    {
        int animStateValue = 2;

        float angleLeft = 0f;
        float angleRight = -180f;

        if (transform.position.x == _waypoints[_currentWaypoint].x)
        {
            _currentWaypoint = (++_currentWaypoint) % _waypoints.Count;

            if (_currentWaypoint == 0)
            {
                Rotate(angleRight);
            }
            else
            {
                Rotate(angleLeft);
            }
        }

        transform.position = Vector3.MoveTowards
            (transform.position, _waypoints[_currentWaypoint], _speed * Time.deltaTime);

        _animator.SetInteger(AnimState, animStateValue);
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, _player.gameObject.transform.position, _speed * Time.deltaTime);
    }

    private void Rotate(float angle)
    {
        Vector2 rotate = transform.localEulerAngles;
        rotate.y = angle;

        transform.localRotation = Quaternion.Euler(rotate);
    }
}