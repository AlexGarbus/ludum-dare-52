using Godot;
using System;

namespace LudumDare52.Objects
{
    [Tool]
    public class PositionBounds : Node
    {
        [Export]
        private Rect2 _boundsRect;

        public bool Disabled { get; set; } = false;

        private Node2D _boundedNode;

        public override void _Ready()
        {
            _boundedNode = (Node2D)Owner;
        }

        public override void _PhysicsProcess(float delta)
        {
            if (Engine.EditorHint || Disabled)
            {
                return;
            }

            _boundedNode.Position = BoundPosition(_boundedNode.Position);
        }

        public override string _GetConfigurationWarning()
        {
            return Owner is Node2D ? "" : "This Node must be a child of a Node2D!";
        }

        private Vector2 BoundPosition(Vector2 position)
        {
            return new Vector2(
                    Mathf.Clamp(position.x, _boundsRect.Position.x, _boundsRect.End.x),
                    Mathf.Clamp(position.y, _boundsRect.Position.y, _boundsRect.End.y)
            );
        }
    }
}