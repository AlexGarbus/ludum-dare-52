using Godot;
using System;

namespace LudumDare52
{
    public class Counter : Node
    {
        [Signal]
        delegate void Changed(int count);

        public int Count 
        {
            get { return _count; } 
            private set
            {
                _count = value;
                EmitSignal(nameof(Changed), _count);
            }
        }

        private int _count = 0;

        public void Add(int value)
        {
            Count += value;
        }
    }
}