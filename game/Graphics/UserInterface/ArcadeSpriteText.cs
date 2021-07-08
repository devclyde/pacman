using osu.Framework.Graphics.Sprites;

namespace pacman.Game.Graphics.UserInterface
{
    public class ArcadeSpriteText : SpriteText
    {
        public int FontSize { get; init; } = 20;

        protected override void LoadComplete()
        {
            Font = new FontUsage("Arcade", size: FontSize);
        }
    }
}
