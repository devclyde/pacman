using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Animations;
using pacman.Game.Stores;

namespace pacman.Game.Elements.Pacman
{
    public class PacmanAnimation : TextureAnimation
    {
        public PlayerState State
        {
            get;
            init;
        }

        public PacmanAnimation()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Size = new osuTK.Vector2(15 * 3);
        }

        [BackgroundDependencyLoader]
        private void Load(NearestTextureStore textures)
        {
            switch (State)
            {
                case PlayerState.Idle:
                    AddFrame(textures.Get("pacman/anim0"));
                    break;
                case PlayerState.Running:
                    AddFrame(textures.Get("pacman/anim0"), 100d);
                    AddFrame(textures.Get("pacman/anim1"), 100d);
                    AddFrame(textures.Get("pacman/anim2"), 100d);
                    AddFrame(textures.Get("pacman/anim1"), 100d);
                    break;
            }
        }
    }

    public enum PlayerState
    {
        Idle,
        Running
    }
}
