using Godot;
using Godot.Collections;
using System;

namespace LudumDare52.Objects.Characters
{
    public class CharacterParticles : Node2D
    {
        private CPUParticles2D[] _particleSystems;

        public override void _Ready()
        {
            _particleSystems = new CPUParticles2D[GetChildren().Count];
            for (int i = 0; i < _particleSystems.Length; i++)
            {
                _particleSystems[i] = (CPUParticles2D)GetChild(i);
            }
        }

        public void SetEmitting(bool value)
        {
            foreach (CPUParticles2D particles in _particleSystems)
            {
                particles.Emitting = value;
            }
        }

        public void OnHealthChanged(int current, int previous)
        {
            if (current == 0)
            {
                SetEmitting(false);
            }
        }
    }
}