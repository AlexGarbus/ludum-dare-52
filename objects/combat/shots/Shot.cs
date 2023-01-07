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

        public PhysicsArea[] Instance()
        {
            var projectiles = new PhysicsArea[_projectileAmount];
            float separation = _projectileAmount == 1 ? 0f : Mathf.Deg2Rad(_spreadDegrees) / _projectileAmount - 1;

            for (int i = 0; i < _projectileAmount; i++)
            {
                projectiles[i] = CreateProjectile(Vector2.Right.Rotated(separation * i) * _projectileSpeed);
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