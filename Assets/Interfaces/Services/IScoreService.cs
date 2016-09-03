
namespace SpaceGame.Interfaces
{
    public interface IScoreService
    {
        /// <summary>
        /// Gets the current score.
        /// </summary>
        /// <returns>int representing the current score</returns>
        int GetScore();

        /// <summary>
        /// Adds points to the current score.
        /// </summary>
        /// <param name="points">points to add to the score.</param>
        void AddToScore(int points);
    }
}
