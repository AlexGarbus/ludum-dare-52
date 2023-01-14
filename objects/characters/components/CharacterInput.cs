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
        delegate void EnterStarted();

        [Signal]
        delegate void CombatStarted();

        [Signal]
        delegate void ExitStarted();

        protected enum State
        {
            ENTER,
            COMBAT,
            EXIT
        }

        [Export(PropertyHint.Range, "0,1000,or_greater")]
        protected float _moveSpeed = 500f;

        [Export]
        private Vector2 _enterDirection;

        protected State InputState
        {
            get { return _inputState; }
            set
            {
                if ( _inputState != value)
                {
                    _inputState = value;
                    EmitStateSignal(_inputState);
                }
            }
        }

        protected Vector2 MoveVector
        {
            get { return _moveVector; }
            set
            {
                if (value != _moveVector)
                {
                    _moveVector = value;
                    EmitSignal("MoveInputReceived", _moveVector);
                }
            }
        }

        private Vector2 _moveVector = Vector2.Zero;
        private State _inputState = State.ENTER;

        public override void _Ready()
        {
            GetNode<Timer>("%EnterTimer").Connect("timeout", this, nameof(OnEnterTimerTimeout));
        }

        public override void _PhysicsProcess(float delta)
        {
            switch (_inputState)
            {
                case State.ENTER:
                    MoveVector = _enterDirection * _moveSpeed; // Move to _Ready.
                    break;
                case State.COMBAT:
                    CombatInput(delta);
                    break;
                case State.EXIT:
                    MoveVector = Vector2.Left * _moveSpeed; // Move to OnHealthChanged.
                    break;
            }
        }

        public virtual void CombatInput(float delta) { }

        public void OnHealthChanged(int current, int previous)
        {
            if (_inputState == State.COMBAT && current == 0)
            {
                InputState = State.EXIT;
            }
        }

        public void OnEnterTimerTimeout()
        {
            MoveVector = Vector2.Zero;
            InputState = State.COMBAT;
        }

        private void EmitStateSignal(State state)
        {
            switch (state)
            {
                case State.ENTER:
                    EmitSignal(nameof(EnterStarted));
                    break;
                case State.COMBAT:
                    EmitSignal(nameof(CombatStarted));
                    break;
                case State.EXIT:
                    EmitSignal(nameof(ExitStarted));
                    break;
            }
        }
    }
}