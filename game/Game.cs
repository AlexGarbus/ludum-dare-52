using LudumDare52.Objects.Characters;
using LudumDare52.Saving;
using Godot;
using System;

namespace LudumDare52.Game
{
    public class Game : Node
    {
        private enum State
        {
            RUNNING,
            OVER
        }

        [Signal]
        delegate void Ended();

        [Export(PropertyHint.File, "*.tscn")]
        private readonly string _introScenePath;

        [Export(PropertyHint.Range, "1,100,or_greater")]
        private readonly int _enemyScore = 100;

        private bool _exited = false;
        private State _state = State.RUNNING;

        private Counter _score;
        private Timer _endTimer;

        public override void _Ready()
        {
            _score = GetNode<Counter>("%Score");
            _endTimer = GetNode<Timer>("%EndTimer");
            GD.Randomize();
        }

        public void OnInputReceived()
        {
            if (_state != State.OVER || _exited)
            {
                return;
            }

            GetTree().ChangeScene(_introScenePath);
            _exited = true;
        }

        public void OnPlayerHealthChanged(int current, int previous)
        {
            if (current == 0)
            {
                _endTimer.Start();
            }
        }

        public void OnEnemyHealthChanged(int current, int previous)
        {
            if (current == 0)
            {
                _score.Add(_enemyScore);
            }
        }

        public void OnEnemySpawned(Character enemy)
        {
            enemy.GetNode<Health>("%Health").Connect("Changed", this, nameof(OnEnemyHealthChanged));
        }

        public void EndGame()
        {
            _state = State.OVER;
            EvaluateScore();
            EmitSignal(nameof(Ended));
        }

        private void EvaluateScore()
        {
            int bestScore = SaveLoad.Load();
            if (_score.Count > bestScore)
            {
                SaveLoad.Save(_score.Count);
            }
        }
    }
}