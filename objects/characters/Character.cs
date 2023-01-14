using LudumDare52.Objects.Combat;
using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class Character : PhysicsArea
    {
        private CharacterInput _input;
        private Health _health;
        private Weapon _weapon;
        private PositionBounds _bounds;

        public override void _Ready()
        {
            _input = GetNode<CharacterInput>("%Input");
            _health = GetNode<Health>("%Health");
            _weapon = GetNode<Weapon>("%Weapon");
            _bounds = GetNode<PositionBounds>("%PositionBounds");

            _input.Connect("MoveInputReceived", this, nameof(SetVelocity));
            _input.Connect("ShootInputReceived", _weapon, "Shoot");
            _input.Connect("CombatStarted", _bounds, "Enable");
            _input.Connect("ExitStarted", _bounds, "Disable");
            _health.Connect("Changed", _input, "OnHealthChanged");
        }
    }
}