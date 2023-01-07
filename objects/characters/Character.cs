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

        public override void _Ready()
        {
            _input = GetNode<CharacterInput>("%Input");
            _health = GetNode<Health>("%Health");
            _weapon = GetNode<Weapon>("%Weapon");

            _input.Connect("MoveInputReceived", this, nameof(SetVelocity));
            _input.Connect("ShootInputReceived", _weapon, "Shoot");
            _health.Connect("Changed", _input, "OnHealthChanged");
        }
    }
}