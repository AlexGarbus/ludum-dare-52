using Godot;
using System;

namespace LudumDare52.Objects.Combat
{
    public class Weapon : Position2D
    {
        [Signal]
        delegate void ShotFired();

        [Export]
        private readonly Vector2 _aimDirection;

        [Export]
        private readonly bool _autoShoot = false;

        [Export]
        private readonly Shot _startShot;

        private bool _canShoot = true;
        private Shot _currentShot;

        public override void _Ready()
        {
            _currentShot = _startShot;
            if (_autoShoot)
            {
                Shoot();
            }
        }

        public void Shoot()
        {
            if (!_canShoot)
            {
                return;
            }

            PhysicsArea[] projectiles = _currentShot.Instance();
            foreach (PhysicsArea projectile in projectiles)
            {
                projectile.GlobalPosition = GlobalPosition;
                AddChild(projectile);
                // TODO: Set collision mask
            }

            _canShoot = false;
            EmitSignal(nameof(ShotFired));
        }

        public void OnCooldownTimeout()
        {
            _canShoot = true;
            if (_autoShoot)
            {
                Shoot();
            }
        }
    }
}