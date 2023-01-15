using Godot;
using LudumDare52.Objects.Characters;

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

        private bool _exited = false;
        private State _state = State.RUNNING;

        private Timer _endTimer;

        public override void _Ready()
        {
            _endTimer = GetNode<Timer>("%EndTimer");
            Health playerHealth = GetNode<Character>("%Player").GetNode<Health>("%Health");
            playerHealth.Connect("Changed", this, nameof(OnPlayerHealthChanged));
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

        public void EndGame()
        {
            _state = State.OVER;
            EmitSignal(nameof(Ended));
        }
    }
}