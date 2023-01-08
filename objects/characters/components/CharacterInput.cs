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

        [Signal]
        delegate void InputStarted();

        [Signal]
        delegate void InputStopped();

        [Export(PropertyHint.Range, "0,1000,or_greater")]
        protected float _moveSpeed = 500f;

        protected bool ReceivingInput
        {
            get { return _receivingInput; }
            set
            {
                if ( _receivingInput != value)
                {
                    _receivingInput = value;
                    EmitSignal(_receivingInput ? nameof(InputStarted) : nameof(InputStopped));
                }
            }
        }

        private bool _receivingInput = true;

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
                ReceivingInput = false;
            }
        }

        public void StartInput() => ReceivingInput = true;

        public void StopInput() => ReceivingInput = false;
    }
}