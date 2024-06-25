using UnityEngine;

public class Sensor_Bandit : MonoBehaviour 
{
    [SerializeField] private LayerMask _layerMask;

    public bool IsGrounded {  get; private set; }

    private void FixedUpdate()
    {
        IsGrounded = IsOnGround();
    }

    private bool IsOnGround()
    {
        float radius = 0.2f;

        return Physics2D.OverlapCircle(transform.position, radius, _layerMask.value);
    }
}
