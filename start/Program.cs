using pacman.Game;
using osu.Framework;
using ofGame = osu.Framework.Game;

namespace pacman.Desktop
{
    internal static class Program
    {
        [System.STAThread]
        internal static void Main()
        {
            using ofGame game = new Application();
            using var host = Host.GetSuitableHost(@"PACMAN");
            host.Run(game);
        }
    }
}
