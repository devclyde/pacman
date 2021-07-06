using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using pacman.Game.Stores;

namespace pacman.Game.Screens
{
    public class GameScreen : Screen
    {
        private Sprite sprite;

        [BackgroundDependencyLoader]
        private void Load(NearestTextureStore nearestTextureStore)
        {
            var texture = nearestTextureStore.Get(@"pacman/full-ball");
            AddInternal(sprite = new()
            {
                Size = texture.Size * 3,
                Texture = texture,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            });
        }
    }
}
