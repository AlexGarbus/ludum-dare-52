using Godot;
using System;

namespace LudumDare52.Objects.Combat
{
    public class Shot : Resource
    {
        [Export]
        private readonly PackedScene _projectile;

        [Export(PropertyHint.Range, "1,3,or_greater")]
        private readonly int _projectileAmount = 1;

        [Export(PropertyHint.Range, "0,1000,or_greater")]
        private readonly float _projectileSpeed = 500f;

        [Export(PropertyHint.Range, "0,180")]
        private readonly float _spreadDegrees = 90f;

        public PhysicsArea[] Instance(Vector2 aimDirection)
        {
            var projectiles = new PhysicsArea[_projectileAmount];
            float spreadRadians = Mathf.Deg2Rad(_spreadDegrees);
            float separation = 0f;
            Vector2 origin = aimDirection;
            if (_projectileAmount > 1)
            {
                separation = spreadRadians / (_projectileAmount - 1);
                origin = aimDirection.Rotated(-spreadRadians / 2);
            }

            for (int i = 0; i < _projectileAmount; i++)
            {
                projectiles[i] = CreateProjectile(origin.Rotated(separation * i) * _projectileSpeed);
            }

            return projectiles;
        }

        private PhysicsArea CreateProjectile(Vector2 velocity)
        {
            PhysicsArea instance = (PhysicsArea)_projectile.Instance();
            instance.SetAsToplevel(true);
            instance.SetVelocity(velocity);
            return instance;
        }
    }
}