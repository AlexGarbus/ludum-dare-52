using Godot;
using System;

namespace LudumDare52.UserInterface
{
    public class Tutorial : Popup
    {
        public override void _Ready()
        {
            Connect("about_to_show", this, nameof(OnAboutToShow));
            Connect("popup_hide", this, nameof(OnHide));
            CallDeferred("popup");
        }

        private void OnAboutToShow()
        {
            GetTree().Paused = true;
        }

        private void OnHide()
        {
            GetTree().Paused = false;
            QueueFree();
        }
    }
}