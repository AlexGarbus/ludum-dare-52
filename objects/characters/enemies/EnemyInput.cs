using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class EnemyInput : CharacterInput
    {
        [Export(PropertyHint.Range, "0,1,or_greater")]
        private float _combatTimeVariance = 0.5f;

        private bool _moving = false;

        private Timer _combatTimer;
        private float _baseCombatTime;

        public override void _Ready()
        {
            _combatTimer = GetNode<Timer>("%CombatTimer");
            _baseCombatTime = _combatTimer.WaitTime;
            base._Ready();
        }

        public void OnCombatTimerTimeout()
        {
            _moving = !_moving;
            if (_moving)
            {
                RandomizeCombatInput();
                StartCombatTimer();
            }
            else
            {
                MoveVector = Vector2.Zero;
                EmitSignal("ShootInputReceived");
            }
        }

        public void StartCombatTimer()
        {
            float time = _baseCombatTime + (float)GD.RandRange(-_combatTimeVariance, _combatTimeVariance);
            _combatTimer.Start(time);
        }

        private void RandomizeCombatInput()
        {
            float angle = Mathf.Deg2Rad(GD.Randi() % 360);
            MoveVector = Vector2.Right.Rotated(angle) * _moveSpeed;
        }
    }
}