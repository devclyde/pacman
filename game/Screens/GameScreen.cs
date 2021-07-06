using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using pacman.Game.Elements.Pacman;
using pacman.Game.Stores;

namespace pacman.Game.Screens
{
    public class GameScreen : Screen
    {
        private Sprite sprite;

        [BackgroundDependencyLoader]
        private void Load()
        {
            var anim = new PacmanAnimation
            {
                State = PlayerState.Running,
            };

            AddInternal(anim);
        }
    }
}
