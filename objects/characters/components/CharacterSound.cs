using Godot;

namespace LudumDare52.Objects.Characters
{
    public class CharacterSound : Node
    {
        private AudioStreamPlayer _damage;
        private AudioStreamPlayer _destroy;

        public override void _Ready()
        {
            _damage = GetNode<AudioStreamPlayer>("%DamageSound");
            _destroy = GetNode<AudioStreamPlayer>("%DestroySound");
        }

        public void OnHealthChanged(int current, int previous)
        {
            if (current == 0)
            {
                _destroy.Play();
            }
            else if (current - previous < 0)
            {
                _damage.Play();
            }
        }
    }
}