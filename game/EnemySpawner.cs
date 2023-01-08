using LudumDare52.Objects.Characters;
using Godot;
using System;

namespace LudumDare52.Game
{
    public class EnemySpawner : Node
    {
        [Signal]
        delegate void Spawned(Character enemy);

        [Export(PropertyHint.Range, "0,10,or_greater")]
        private readonly int _maxEnemies = 10;

        [Export]
        private readonly float _spawnPositionX = 1920f;

        [Export]
        private readonly float _minSpawnPositionY = 0f;

        [Export]
        private readonly float _maxSpawnPositionY = 1080f;

        [Export]
        private readonly PackedScene[] _enemies;

        public void Spawn()
        {
            if (GetChildren().Count >= _maxEnemies)
            {
                return;
            }

            Character enemy = (Character)_enemies[GD.Randi() % _enemies.Length].Instance();
            enemy.Position = GetSpawnPosition();
            AddChild(enemy);
            EmitSignal(nameof(Spawned), enemy);
        }

        private Vector2 GetSpawnPosition()
        {
            return new Vector2(_spawnPositionX, (float)GD.RandRange(_minSpawnPositionY, _maxSpawnPositionY));
        }
    }
}