using osu.Framework.Logging;

namespace pacman.Game
{
    public sealed class GameManager
    {
        private int score;

        public int Score
        {
            get => score;
        }

        public GameManager()
        {
            score = 0;
        }

        public void ResetState()
        {
            Logger.Log("Game State has been reseted!");
            score = 0;
        }

        public void IncreaseScore(int points)
        {
            score += points;
        }
    }
}
