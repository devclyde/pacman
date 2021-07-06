using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using pacman.Game.Stores;

namespace pacman.Game.Elements.Pacman
{
    public class PlayablePacman : CompositeDrawable
    {
        private PacmanAnimation sprite;

        [BackgroundDependencyLoader]
        private void Load()
        {}
    }
}
