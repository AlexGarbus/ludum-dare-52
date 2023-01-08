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
        private Timer _cooldown;

        public override void _Ready()
        {
            _cooldown = GetNode<Timer>("%Cooldown");
            _currentShot = _startShot;
            if (_autoShoot)
            {
                Shoot();
            }
        }

        public Shot GetCurrentShot() => _currentShot;

        public void SetCurrentShot(Shot value) => _currentShot = value;

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
                GetTree().Root.GetNode("Game").AddChild(projectile);
            }

            _canShoot = false;
            _cooldown.Start();
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

        public void OnHealthChanged(int current, int previous)
        {
            if (current == 0)
            {
                _canShoot = false;
                _cooldown.Stop();
            }
            else if (current - previous < 0)
            {
                _currentShot = _startShot;
            }
        }
    }
}