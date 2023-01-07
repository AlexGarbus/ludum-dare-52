using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class Character : PhysicsArea
    {
        private Movement _movement;

        public override void _Ready()
        {
            _movement = GetNode<Movement>("%Movement");
        }

        public override void _PhysicsProcess(float delta)
        {
            Velocity = _movement.GetTranslation();
            base._PhysicsProcess(delta);
        }
    }
}