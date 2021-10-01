using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;
using pacman.Game.Graphics.UserInterface;

namespace pacman.Game.Screens
{
    public class GameScreen : Screen
    {
        private GameManager gameManager;

        public GameScreen()
        {
            AddInternal(new ArcadeSpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "GAME START"
            });
        }

        [BackgroundDependencyLoader]
        private void Load(GameManager gameManager)
        {
            this.gameManager = gameManager;
            gameManager.ResetState();
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            return base.OnKeyDown(e);
        }
    }
}
