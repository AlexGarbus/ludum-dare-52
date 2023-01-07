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

        [Export(PropertyHint.Layers2dPhysics)]
        private readonly uint _collisionLayer;

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

            PhysicsArea[] projectiles = _currentShot.Instance(_aimDirection);
            foreach (PhysicsArea projectile in projectiles)
            {
                projectile.GlobalPosition = GlobalPosition;
                projectile.CollisionLayer = _collisionLayer;
                AddChild(projectile);
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