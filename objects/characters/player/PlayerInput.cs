using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class PlayerInput : CharacterInput
    {
        private Vector2 MoveVector
        {
            get { return _moveVector; }
            set
            {
                if (value != _moveVector)
                {
                    _moveVector = value;
                    EmitSignal("MoveInputReceived", _moveVector);
                }
            }
        }

        private Vector2 _moveVector = Vector2.Zero;

        public override void _PhysicsProcess(float delta)
        {
            MoveVector = new Vector2(
                    Input.GetAxis("move_left", "move_right"),
                    Input.GetAxis("move_up", "move_down")
            ).Normalized() * _moveSpeed;
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event.IsActionPressed("action"))
            {
                EmitSignal("ShootInputReceived");
            }
        }
    }
}