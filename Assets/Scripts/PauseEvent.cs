using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PauseEvent : MonoBehaviour
{
    public static event Action PausePressed;

    private InputSystem_Actions inputActions;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Player.Pause.performed += OnPausePerformed;
        inputActions.Player.Pause.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Pause.performed -= OnPausePerformed;
        inputActions.Player.Pause.Disable();
    }

    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        PausePressed?.Invoke();
    }
}
