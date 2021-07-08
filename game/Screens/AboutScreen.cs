using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;
using pacman.Game.Graphics.UserInterface;

namespace pacman.Game.Screens
{
    public class AboutScreen : Screen
    {
        public AboutScreen()
        {
            AddInternal(new ArcadeSpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "ABOUT"
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
