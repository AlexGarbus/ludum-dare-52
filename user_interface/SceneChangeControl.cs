using Godot;
using System;

namespace LudumDare52.UserInterface
{
    // TODO: Scrap?
    public class SceneChangeControl : Control
    {
        [Export(PropertyHint.File, "*.tscn")]
        private string _scene_path;

        private bool _scene_loaded = false;

        public void ChangeScene()
        {
            if (!Visible || _scene_loaded)
            {
                return;
            }

            GetTree().ChangeScene(_scene_path);
            _scene_loaded = true;
        }
    }
}