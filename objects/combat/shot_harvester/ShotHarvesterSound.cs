using Godot;

namespace LudumDare52.Objects.Combat
{
    public class ShotHarvesterSound : Node
    {
        private AudioStreamPlayer _harvest;

        public override void _Ready()
        {
            _harvest = GetNode<AudioStreamPlayer>("%HarvestSound");
        }

        public void OnShotHarvested(Shot shot)
        {
            _harvest.Play();
        }
    }
}