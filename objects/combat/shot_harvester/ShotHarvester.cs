using LudumDare52.Objects.Characters;
using Godot;
using System;

namespace LudumDare52.Objects.Combat
{
    public class ShotHarvester : Area2D
    {
        [Signal]
        delegate void ShotHarvested(Shot shot);

        public override void _Ready()
        {
            Connect("area_entered", this, nameof(OnAreaEntered));
        }

        private void OnAreaEntered(Area2D area)
        {
            if (area is Character character && character.GetNode<Health>("%Health").Current == 0)
            {
                EmitSignal(nameof(ShotHarvested), character.GetNode<Weapon>("%Weapon").GetCurrentShot());
                character.QueueFree();
            }
        }
    }
}