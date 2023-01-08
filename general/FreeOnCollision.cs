using Godot;
using System;

namespace LudumDare52
{
    public class FreeOnCollision : Node
    {
        public void OnAreaCollision(Area2D area)
        {
            Owner.QueueFree();
        }
    }
}