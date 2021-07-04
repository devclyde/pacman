using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace pacman.Game
{
    public class Application : ApplicationBase
    {
        private DependencyContainer dependencies;

        private Box box;

        [BackgroundDependencyLoader]
        private void Load()
        {
            Add(box = new()
            {
                Size = new Vector2(200),
                Colour = Color4.Red,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            });
        }

        protected override void Update()
        {
            box.Rotation += (float)Time.Elapsed / 10;

            base.Update();
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
            => dependencies = new(base.CreateChildDependencies(parent));
    }
}
