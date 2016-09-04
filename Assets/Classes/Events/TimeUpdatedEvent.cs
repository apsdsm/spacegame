namespace SpaceGame.Events
{
    /// <summary>
    /// Called when time updates. Should be called once per second.
    /// </summary>
    /// <param name="timeRemaining">time remaining in seconds.</param>
    public delegate void TimeUpdatedEvent(int timeRemaining);
}
