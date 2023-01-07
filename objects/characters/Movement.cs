using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public abstract class Movement : Node
    {
        [Export(PropertyHint.Range, "0,1000,or_greater")]
        protected float _speed = 500f;

        public abstract Vector2 GetTranslation();
    }
}