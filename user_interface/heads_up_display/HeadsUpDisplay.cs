using LudumDare52.Game;
using Godot;
using System;

namespace LudumDare52.UserInterface
{
    public class HeadsUpDisplay : Control
    {
        [Export]
        private readonly string _scorePrefix = "Score: ";

        private Label _scoreLabel;

        public override void _Ready()
        {
            _scoreLabel = GetNode<Label>("%Score");
        }

        public void OnScoreChanged(int value)
        {
            _scoreLabel.Text = _scorePrefix + value;
        }
    }
}