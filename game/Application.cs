using osu.Framework.Allocation;
using osu.Framework.Screens;
using pacman.Game.Screens;

namespace pacman.Game
{
    public class Application : ApplicationBase
    {
        private DependencyContainer dependencies;

        [BackgroundDependencyLoader]
        private void Load()
        {
            var screens = new ScreenStack();
            screens.Push(new GameScreen());

            Add(screens);
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
            => dependencies = new(base.CreateChildDependencies(parent));
    }
}
