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

        protected bool _receivingInput = true;

        public override void _PhysicsProcess(float delta)
        {
            if (_receivingInput)
            {
                OnPhysicsProcess(delta);
            }
        }

        public abstract void OnPhysicsProcess(float delta);

        public void OnHealthChanged(int current, int previous)
        {
            if (_receivingInput && current == 0)
            {
                EmitSignal(nameof(MoveInputReceived), Vector2.Left * _moveSpeed);
                _receivingInput = false;
            }
        }
    }
}