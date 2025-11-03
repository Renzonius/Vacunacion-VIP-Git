using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement8Directions : PlayerMovement
{
    private void Awake()
    {
        rbBase.gravityScale = 0f;
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            Movement();
        }
    }
    public override void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
        inputDirection = inputDirection.normalized;
    }

    public override void Movement()
    {
        rbBase.MovePosition(rbBase.position + inputDirection * movementSpeedBase * Time.fixedDeltaTime);
    }
}
