using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics.Textures;
using ofGame = osu.Framework.Game;

namespace pacman.Game
{
    public abstract class ApplicationBase : ofGame
    {
        private DependencyContainer dependencies;

        private TextureStore textureStore;

        [BackgroundDependencyLoader]
        private void Load(FrameworkConfigManager config)
        {
            dependencies.Cache(textureStore = new(Textures));

            config.GetBindable<FrameSync>(FrameworkSetting.FrameSync).Value = FrameSync.Unlimited;
            Host.Window.Title = "PACMAN";
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
            => dependencies = new(base.CreateChildDependencies(parent));
    }
}
