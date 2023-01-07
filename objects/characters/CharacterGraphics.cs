using Godot;
using System;

namespace LudumDare52.Objects.Characters
{
    public class CharacterGraphics : Node
    {
        private AnimationPlayer _animationPlayer;

        public override void _Ready()
        {
            _animationPlayer = GetNode<AnimationPlayer>("%AnimationPlayer");
        }

        public void OnHealthChanged(int current)
        {
            if (current == 0)
            {
                _animationPlayer.Play("destroy");
            }
        }
    }
}