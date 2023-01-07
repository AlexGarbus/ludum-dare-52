using Godot;
using System;

namespace LudumDare52.Objects
{
    public class PhysicsArea : Area2D
    {
        public Vector2 Velocity { get; set; }

        public override void _PhysicsProcess(float delta)
        {
            Position += Velocity * delta;
        }
    }
}