using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class PlayerMovement : Movement
    {
        public override Vector2 GetTranslation()
        {
            return new Vector2(
                    Input.GetAxis("move_left", "move_right"),
                    Input.GetAxis("move_up", "move_down")
            ).Normalized() * _speed;
        }
    }
}