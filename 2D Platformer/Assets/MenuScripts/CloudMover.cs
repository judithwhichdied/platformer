using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private Vector3 _defaultPosition;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
        {
            transform.position = _defaultPosition;
        }
    }
}