using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using pacman.Game.Stores;
using static pacman.Resources.ResourceAssembly;
using ofGame = osu.Framework.Game;

namespace pacman.Game
{
    public abstract class ApplicationBase : ofGame
    {
        private DependencyContainer dependencies;

        private TextureStore textureStore;
        private NearestTextureStore nearestTextureStore;

        [BackgroundDependencyLoader]
        private void Load(FrameworkConfigManager config)
        {
            Resources.AddStore(new DllResourceStore(Assembly));

            dependencies.Cache(textureStore = new(Textures));
            dependencies.Cache(nearestTextureStore = new(Textures));

            AddFont(Resources, @"Fonts/Arcade");

            config.GetBindable<FrameSync>(FrameworkSetting.FrameSync).Value = FrameSync.Unlimited;
            Host.Window.Title = "PACMAN";
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
            => dependencies = new(base.CreateChildDependencies(parent));
    }
}
