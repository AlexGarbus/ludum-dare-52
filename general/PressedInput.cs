using Godot;
using System;

namespace LudumDare52
{
    public class PressedInput : Node
    {
        [Signal]
        delegate void InputReceived();

        public override void _UnhandledInput(InputEvent @event)
        {
            if (IsEventPressed(@event))
            {
                EmitSignal(nameof(InputReceived));
            }
        }

        private bool IsEventPressed(InputEvent @event)
        {
            InputEventKey inputEventKey = @event as InputEventKey;
            InputEventJoypadButton inputEventJoypadButton = @event as InputEventJoypadButton;
            return inputEventKey != null && inputEventKey.Pressed && !inputEventKey.IsEcho()
                || inputEventJoypadButton != null && inputEventJoypadButton.Pressed;
        }
    }
}