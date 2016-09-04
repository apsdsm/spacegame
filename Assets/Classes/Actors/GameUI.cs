// unity
using UnityEngine;
using UnityEngine.UI;

// game
using SpaceGame.Interfaces;

// vendor
using Fletch;

namespace SpaceGame.Actors
{
    public class GameUI : MonoBehaviour
    {

        [Tooltip("The score text element")]
        public Text scoreText;

        [Tooltip("The time text element")]
        public Text timeText;

        // reference to score service
        private IScoreService score;

        // reference to time service
        private ITimeService time;

        void Awake()
        {
            score = IOC.Resolve<IScoreService>();

            score.ScoreUpdated += UpdateScoreText;

            time = IOC.Resolve<ITimeService>();

            time.TimeUpdated += UpdateTimeText;
        }

        /// <summary>
        /// Update the text that shows the current score.
        /// </summary>
        /// <param name="score">new score value</param>
        private void UpdateScoreText(int score)
        {
            scoreText.text = score.ToString().PadLeft(8, '0');
        }

        /// <summary>
        /// Update the text that shows the current time.
        /// </summary>
        /// <param name="time">current time in seconds</param>
        private void UpdateTimeText(int time)
        {
            int seconds = time % 60;

            int minutes = (time - seconds) / 60;

            timeText.text = minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        }
    }
}
