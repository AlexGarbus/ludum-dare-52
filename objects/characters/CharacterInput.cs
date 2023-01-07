using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public abstract class CharacterInput : Node
    {
        [Signal]
        delegate void MoveInputReceived(Vector2 moveVector);

        [Signal]
        delegate void ShootInputReceived();

        [Export(PropertyHint.Range, "0,1000,or_greater")]
        protected float _moveSpeed = 500f;
    }
}