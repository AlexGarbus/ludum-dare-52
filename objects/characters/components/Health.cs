using Godot;

namespace LudumDare52.Objects.Characters
{
    public class Health : Node
    {
        [Signal]
        delegate void Changed(int current, int previous);

        [Export(PropertyHint.Range, "1,10,or_greater")]
        private readonly int _max = 3;

        [Export(PropertyHint.Layers2dPhysics)]
        private uint _hurtMask;

        public int Current
        {
            get { return _current; }
            set
            {
                if (_current != value)
                {
                    int previous = _current;
                    _current = Mathf.Clamp(value, 0, _max);
                    EmitSignal(nameof(Changed), _current, previous);
                }
            }
        }

        private int _current;

        public override void _Ready()
        {
            Current = _max;
        }

        public int GetMax() => _max;

        public void OnAreaEntered(Area2D area)
        {
            if (Current == 0)
            {
                return;
            }

            if ((area.CollisionLayer & _hurtMask) != 0)
            {
                Current--;
            }
        }
    }
}