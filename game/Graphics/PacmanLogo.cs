using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;

namespace pacman.Game.Graphics
{
    public class PacmanLogo : CompositeDrawable
    {
        private readonly SpriteText textLogo1;
        private readonly SpriteText textLogo2;

        public PacmanLogo()
        {
            AddRangeInternal(new[]
            {
                textLogo1 = new()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "PAC-MAN",
                    Font = new FontUsage(family: "Arcade", size: 80),
                    Colour = Colour4.Yellow,
                    Y = 10,
                    Spacing = new osuTK.Vector2(10)
                },
                textLogo2 = new()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "PAC-MAN",
                    Font = new FontUsage(family: "Arcade", size: 80),
                    Colour = Colour4.Gold,
                    X = -10,
                    Spacing = new osuTK.Vector2(10)
                }
            });
        }

        protected override void LoadComplete()
        {
            textLogo2
                .FadeColour(Colour4.FromHex("#ffcc22"))
                .Then()
                .Delay(500)
                .FadeColour(Colour4.FromHex("#eeaa00"))
                .Loop(500);

            textLogo1
                .FadeColour(Colour4.FromHex("#eeaa00"))
                .Then()
                .Delay(500)
                .FadeColour(Colour4.FromHex("#eeaa00").Darken(0.2f))
                .Loop(500);

            base.LoadComplete();
        }
    }
}
