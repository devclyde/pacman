using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osuTK.Graphics.ES30;

namespace pacman.Game.Stores
{
    public sealed class NearestTextureStore : TextureStore
    {
        public NearestTextureStore(IResourceStore<TextureUpload> store)
            : base(store, filteringMode: All.Nearest)
        {}
    }
}
