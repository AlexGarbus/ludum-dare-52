using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class PlayerInput : CharacterInput
    {
        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event.IsActionPressed("action") && InputState == State.COMBAT)
            {
                EmitSignal("ShootInputReceived");
            }
        }

        public override void CombatInput(float delta)
        {
            MoveVector = new Vector2(
                    Input.GetAxis("move_left", "move_right"),
                    Input.GetAxis("move_up", "move_down")
            ).Normalized() * _moveSpeed;
        }
    }
}