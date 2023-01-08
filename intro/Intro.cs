using Godot;
using System;

namespace LudumDare52
{
    public class Intro : Node
    {
        [Export(PropertyHint.File, "*.tscn")]
        private readonly string _gameScenePath;

        private AnimationPlayer _animationPlayer;

        private bool _exited = false;

        public override void _Ready()
        {
            _animationPlayer = GetNode<AnimationPlayer>("%AnimationPlayer");
        }

        public void OnInputReceived()
        {
            if (_animationPlayer.IsPlaying() || _exited)
            {
                return;
            }

            _animationPlayer.Play("exit");
            _exited = true;
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