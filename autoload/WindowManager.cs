using Godot;

namespace LudumDare52.AutoLoad
{
    public class WindowManager : Node
    {
        public override void _Ready()
        {
            if (!OS.GetName().Equals("HTML5"))
            {
                OS.WindowMaximized = true;
            }
        }
    }
}