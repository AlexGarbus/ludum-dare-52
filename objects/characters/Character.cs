using LudumDare52.Objects.Combat;
using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class Character : PhysicsArea
    {
        private CharacterInput _input;
        private Weapon _weapon;

        public override void _Ready()
        {
            _input = GetNode<CharacterInput>("%Input");
            _weapon = GetNode<Weapon>("%Weapon");

            _input.Connect("MoveInputReceived", this, nameof(SetVelocity));
            _input.Connect("ShootInputReceived", _weapon, "Shoot");
        }
    }
}