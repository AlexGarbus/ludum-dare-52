using LudumDare52.Game;
using LudumDare52.Objects.Combat;
using Godot;
using System;

namespace LudumDare52.UserInterface
{
    public class HeadsUpDisplay : Control
    {
        [Export]
        private readonly string _scorePrefix = "Score: ";

        private Label _scoreLabel;
        private Label _shotLabel;

        public override void _Ready()
        {
            _scoreLabel = GetNode<Label>("%Score");
            _shotLabel = GetNode<Label>("%Shot");
        }

        public void OnScoreChanged(int value)
        {
            _scoreLabel.Text = _scorePrefix + value;
        }

        public void OnWeaponShotChanged(Shot shot)
        {
            _shotLabel.Text = shot.GetTitle();
        }
    }
}