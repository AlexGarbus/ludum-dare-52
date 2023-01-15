using Godot;
using System;

namespace LudumDare52
{
    public class Intro : Node
    {
        [Export(PropertyHint.File, "*.tscn")]
        private readonly string _gameScenePath;

        private AnimationPlayer _animationPlayer;

        public override void _Ready()
        {
            _animationPlayer = GetNode<AnimationPlayer>("%AnimationPlayer");
        }

        public void OnInputReceived()
        {
            if (_animationPlayer.IsPlaying())
            {
                return;
            }

            _animationPlayer.Play("exit");
        }

        public void OnAnimationFinished(string anim_name)
        {
            if (anim_name.Equals("exit"))
            {
                GetTree().ChangeScene(_gameScenePath);
            }
        }
    }
}