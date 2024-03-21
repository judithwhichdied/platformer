using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public float InputX { get; private set; }

    private void Update()
    {
        InputX = Input.GetAxis(Horizontal);
    }
}
