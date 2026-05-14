using System;
using UnityEngine;

public static class InputInterpreter
{
    public static PlayerInput ReadInputValues(InputActions actions)
    {
        Vector2 movingDirection = actions.Player.Move.ReadValue<Vector2>();
        Vector2 lookingDelta = actions.Player.Look.ReadValue<Vector2>();
        bool hasJumped = actions.Player.Jump.WasPressedThisFrame();
        bool sprinting = actions.Player.Sprint.IsPressed();
        bool shooting = actions.Player.Attack.IsPressed();
        bool hasInteracted = actions.Player.Interact.WasPressedThisFrame();

        return new PlayerInput()
        {
            MovingDirection = new(movingDirection.x, 0f, movingDirection.y),
            LookingDelta = new Vector2(lookingDelta.x, lookingDelta.y),
            HasJumped = hasJumped,
            Sprinting = sprinting,
            Shooting = shooting,
            HasInteracted = hasInteracted,
        };
    }
}
