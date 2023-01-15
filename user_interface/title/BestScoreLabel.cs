using Godot;
using LudumDare52.Saving;

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