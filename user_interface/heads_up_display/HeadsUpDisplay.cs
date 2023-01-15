using LudumDare52.Game;
using LudumDare52.Objects.Characters;
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
        private HealthDisplay _healthDisplay;

        public override void _Ready()
        {
            _scoreLabel = GetNode<Label>("%Score");
            _shotLabel = GetNode<Label>("%Shot");
            _healthDisplay = GetNode<HealthDisplay>("%HealthDisplay");
        }

        public void Initialize(Character player, GameScore score)
        {
            player.GetNode<Weapon>("%Weapon").Connect("ShotChanged", this, nameof(OnWeaponShotChanged));
            _healthDisplay.Initialize(player.GetNode<Health>("%Health"));
            score.Connect("Changed", this, nameof(OnScoreChanged));
        }

        private void OnScoreChanged(int current)
        {
            _scoreLabel.Text = _scorePrefix + current;
        }

        private void OnWeaponShotChanged(Shot shot)
        {
            _shotLabel.Text = shot.GetTitle();
        }
    }
}