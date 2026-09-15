using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("Player").Enable();
    }

    public Vector2 Move() => playerInput.actions["Move"].ReadValue<Vector2>();
    // public bool JumpTriggered() => playerInput.actions["Jump"].triggered;
    // public bool JumpHeld() => playerInput.actions["Jump"].ReadValue<float>() > 0.1;
}
