using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _character;

    private float _speed = 4.0f;

    private void Update()
    {
        if (_character != null)
            transform.position = Vector3.Lerp(transform.position, _character.position, _speed * Time.deltaTime);
    }
}
