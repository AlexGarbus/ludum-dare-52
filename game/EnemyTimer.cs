using Godot;

namespace LudumDare52.Game
{
    public class EnemyTimer : Timer
    {
        [Export(PropertyHint.Range, "0.05,10,or_greater")]
        private float _minWaitTime = 0.05f;

        [Export(PropertyHint.Range, "0.05,10,or_greater")]
        private float _waitTimeInterval = 0.05f;

        public override void _Ready()
        {
            Connect("timeout", this, nameof(OnTimeout));
        }

        private void OnTimeout()
        {
            WaitTime = Mathf.Max(WaitTime - _waitTimeInterval, _minWaitTime);
        }
    }
}