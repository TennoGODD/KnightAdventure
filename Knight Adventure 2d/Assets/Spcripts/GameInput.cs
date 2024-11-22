using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions PlayerInputActions;
    public static GameInput Instance {  get; private set; }
    public event EventHandler OnPlayerAttack;
    private void Awake()
    {
        Instance = this;
        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Enable();
        PlayerInputActions.Combat.Attack.started += PlayerAttack_Started;
    }
    private void PlayerAttack_Started(InputAction.CallbackContext obj)
    {
        OnPlayerAttack?.Invoke(this,EventArgs.Empty);
    }
    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = PlayerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }
    public Vector3 GetMousePosition()
    {
        Vector3 mousepos = Mouse.current.position.ReadValue();
        return mousepos;
    }
}
