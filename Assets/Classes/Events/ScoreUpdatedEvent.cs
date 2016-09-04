namespace SpaceGame.Events
{
    /// <summary>
    /// Called each time the score is updated.
    /// </summary>
    /// <param name="score">The current score.</param>
    public delegate void ScoreUpdatedEvent(int score);
}
