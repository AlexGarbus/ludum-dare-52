using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class Health : Node
    {
        [Export(PropertyHint.Range, "1,10,or_greater")]
        private readonly int _max = 3;

        [Signal]
        delegate void Changed(int current, int previous);

        public int Current
        {
            get { return _current; }
            set
            {
                int previous = _current;
                _current = Mathf.Clamp(value, 0, _max);
                EmitSignal(nameof(Changed), _current, previous);
            }
        }

        private int _current;

        public override void _Ready()
        {
            Current = _max;
        }
    }
}