using Godot;

namespace LudumDare52.Objects.Characters
{
    public class CharacterGraphics : Node
    {
        private AnimationPlayer _animationPlayer;

        public override void _Ready()
        {
            _animationPlayer = GetNode<AnimationPlayer>("%AnimationPlayer");
        }

        public void OnHealthChanged(int current, int previous)
        {
            if (current == 0)
            {
                _animationPlayer.Play("destroy");
            }
            else if (current - previous < 0)
            {
                _animationPlayer.Play("damage");
            }
        }
    }
}