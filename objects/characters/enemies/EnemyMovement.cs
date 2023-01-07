using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class EnemyMovement : Movement
    {
        public override Vector2 GetTranslation()
        {
            return Vector2.Zero;
        }
    }
}