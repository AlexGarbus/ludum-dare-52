using LudumDare52.Saving;
using Godot;
using System;

namespace LudumDare52.UserInterface
{
    public class BestScoreLabel : Label
    {
        [Export]
        private readonly string _prefix = "Best score: ";

        public override void _Ready()
        {
            Text = _prefix + SaveLoad.Load();
        }
    }
}