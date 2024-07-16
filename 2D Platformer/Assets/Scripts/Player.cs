using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private KeyCode _requiredKey = KeyCode.F;

    public float InputX { get; private set; }

    public event Action KeyPressed;

    private void Update()
    {
        InputX = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(_requiredKey))
        {
            KeyPressed?.Invoke();
        }
    }
}
