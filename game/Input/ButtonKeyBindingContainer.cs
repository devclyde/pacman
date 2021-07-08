using System.Collections.Generic;
using osu.Framework.Input.Bindings;

namespace pacman.Game.Input
{
    public class ButtonKeyBindingContainer : KeyBindingContainer<ButtonInputAction>
    {
        public override IEnumerable<IKeyBinding> DefaultKeyBindings => new[]
        {
            new KeyBinding(new[] { InputKey.Left }, ButtonInputAction.Previous),
            new KeyBinding(new[] { InputKey.Right }, ButtonInputAction.Next),
            new KeyBinding(new[] { InputKey.Up }, ButtonInputAction.Previous),
            new KeyBinding(new[] { InputKey.Down }, ButtonInputAction.Next),
            new KeyBinding(new[] { InputKey.Space }, ButtonInputAction.Press),
            new KeyBinding(new[] { InputKey.Enter }, ButtonInputAction.Press),
        };

        public ButtonKeyBindingContainer(KeyCombinationMatchingMode keyCombinationMatchingMode = KeyCombinationMatchingMode.Any, SimultaneousBindingMode simultaneousBindingMode = SimultaneousBindingMode.All)
            : base(simultaneousBindingMode, keyCombinationMatchingMode)
        {
        }
    }
}
