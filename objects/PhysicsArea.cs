using Godot;
using System;

namespace LudumDare52.Objects
{
    public class PhysicsArea : Area2D
    {
        private Vector2 _velocity;

        public override void _PhysicsProcess(float delta)
        {
            Position += _velocity * delta;
        }

        public Vector2 GetVelocity() => _velocity;

        public Vector2 SetVelocity(Vector2 value) => _velocity = value;
    }
}