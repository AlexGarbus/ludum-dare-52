using LudumDare52.Objects.Characters;
using LudumDare52.UserInterface;
using Godot;
using System;

namespace LudumDare52.Game
{
    public class GameUserInterface : CanvasLayer
    {
        public override void _Ready()
        {
            Character player = GetNode<Character>("%Player");
            GameScore score = GetNode<GameScore>("%Score");
            GetNode<HeadsUpDisplay>("%HeadsUpDisplay").Initialize(player, score);
        }
    }
}