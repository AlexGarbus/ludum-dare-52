using Godot;
using System;

namespace LudumDare52.Objects.Combat
{
    public class Weapon : Position2D
    {
        [Export]
        private readonly Vector2 _aimDirection;

        [Export]
        private readonly Shot _startShot;

        private Shot _currentShot;

        public override void _Ready()
        {
            _currentShot = _startShot;
        }

        public void Shoot()
        {
            PhysicsArea[] projectiles = _currentShot.Instance();
            foreach (PhysicsArea projectile in projectiles)
            {
                projectile.GlobalPosition = GlobalPosition;
                AddChild(projectile);
                // TODO: Set collision mask
            }

            // TODO: Cooldown
        }
    }
}