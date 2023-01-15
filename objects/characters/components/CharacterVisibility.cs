using Godot;

namespace LudumDare52.Objects.Characters
{
    public class CharacterVisibility : VisibilityNotifier2D
    {
        private Health _health;

        public override void _Ready()
        {
            _health = GetNode<Health>("%Health");
            Connect("screen_exited", this, nameof(OnScreenExited));
        }

        private void OnScreenExited()
        {
            if (_health.Current == 0)
            {
                Owner.QueueFree();
            }
        }
    }
}