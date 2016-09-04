using SpaceGame.Events;

namespace SpaceGame.Interfaces
{
    public interface IScoreService
    {
        /// <summary>
        /// Adds points to the current score.
        /// </summary>
        /// <param name="points">points to add to the score.</param>
        void AddToScore(int points);

        /// <summary>
        /// Should be called when the score is updated.
        /// </summary>
        event ScoreUpdatedEvent ScoreUpdated;

        /// <summary>
        /// Provide an accessor for the current score.
        /// </summary>
        int currentScore { get; }
    }
}
