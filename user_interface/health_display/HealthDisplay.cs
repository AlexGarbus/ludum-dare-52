using LudumDare52.Objects.Characters;
using Godot;
using System;

namespace LudumDare52.UserInterface
{
    public class HealthDisplay : HBoxContainer
    {
        private TextureRect _baseHeart;
        private TextureRect[] _hearts;

        public override void _Ready()
        {
            _baseHeart = GetNode<TextureRect>("Heart");
        }

        public void Initialize(Health health)
        {
            CreateHearts(health.GetMax());
            OnHealthChanged(health.Current, health.Current);
            health.Connect("Changed", this, nameof(OnHealthChanged));
        }

        private void CreateHearts(int amount)
        {
            _hearts = new TextureRect[amount];
            _hearts[0] = _baseHeart;
            for (int i = 1; i < amount; i++)
            {
                _hearts[i] = (TextureRect)_hearts[0].Duplicate();
                AddChild(_hearts[i]);
            }
        }

        private void OnHealthChanged(int current, int previous)
        {
            for (int i = 0; i < _hearts.Length; i++)
            {
                _hearts[i].Visible = i < current;
            }
        }
    }
}