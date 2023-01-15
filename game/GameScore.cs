using Godot;
using LudumDare52.Objects.Characters;
using LudumDare52.Saving;

namespace LudumDare52.Game
{
    public class GameScore : Node
    {
        [Signal]
        delegate void Changed(int current);

        [Export(PropertyHint.Range, "0,100,or_greater")]
        private readonly int _enemyPoints = 100;

        public int Current
        {
            get { return _current; }
            private set
            {
                _current = value;
                EmitSignal(nameof(Changed), _current);
            }
        }

        private int _current = 0;

        public void Add(int value) => Current += value;

        public void EvaluateScore()
        {
            int bestScore = SaveLoad.Load();
            if (Current > bestScore)
            {
                SaveLoad.Save(Current);
            }
        }

        public void OnEnemySpawned(Character enemy)
        {
            enemy.GetNode<Health>("%Health").Connect("Changed", this, nameof(OnEnemyHealthChanged));
        }

        private void OnEnemyHealthChanged(int current, int previous)
        {
            if (current == 0)
            {
                Current += _enemyPoints;
            }
        }
    }
}