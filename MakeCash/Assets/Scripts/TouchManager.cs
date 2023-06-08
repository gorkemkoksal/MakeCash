using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    public static TouchManager Instance { get; private set; }
    public static event Action onAnyTouch;
    private void Awake()
    {
        Instance = this;
    }
    public void Touch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onAnyTouch?.Invoke();
        }
    }
}
