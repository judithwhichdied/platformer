using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private KeyCode _vampiricAbilityKey = KeyCode.F;

    public event Action KeyPressed;

    public float InputX { get; private set; }

    private void Update()
    {
        InputX = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(_vampiricAbilityKey))
        {
            KeyPressed?.Invoke();
        }
    }
}
