using SpaceGame.Events;

namespace SpaceGame.Interfaces
{
    public interface ITimeService
    {
        /// <summary>
        /// Set the time for the countdown.
        /// </summary>
        /// <param name="seconds">time to set in seconds.</param>
        void SetCountdown(int seconds);

        /// <summary>
        /// Add seconds to the current countdown.
        /// </summary>
        /// <param name="seconds">seconds to add.</param>
        void AddSeconds(int seconds);

        /// <summary>
        /// The countdown will start.
        /// </summary>
        void StartCountdown();

        /// <summary>
        /// The countdown will pause.
        /// </summary>
        void PauseCountdown();

        /// <summary>
        /// Event should be called once per second.
        /// </summary>
        event TimeUpdatedEvent TimeUpdated;

        /// <summary>
        /// Event is called when countdown reaches zero.
        /// </summary>
        event CountdownFinishedEvent CountdownFinished;

        /// <summary>
        /// Return the current time in seconds.
        /// </summary>
        int currentTime { get; }
    }
}
