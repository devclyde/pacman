using osu.Framework.Screens;
using osu.Framework.Graphics;
using pacman.Game.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osuTK.Input;
using osu.Framework.Allocation;

namespace pacman.Game.Screens
{
    public class OptionsScreen : Screen
    {
        public OptionsScreen()
        {
            AddInternal(new ArcadeSpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "OPTIONS MENU"
            });
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            return base.OnKeyDown(e);
        }
    }
}
