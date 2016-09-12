// unity
using UnityEngine;
using UnityEngine.UI;

// game
using SpaceGame.Interfaces;
using SpaceGame.Events;

// vendor
using Fletch;
using System;

namespace SpaceGame.Actors
{
    /// <summary>
    /// Provides the UI for the main game.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class GameUI : MonoBehaviour, IGameUI
    {

        [Tooltip("The score text element")]
        public Text scoreText;

        [Tooltip("The time text element")]
        public Text timeText;

        // reference to score service
        private IScoreService score;

        // reference to time service
        private ITimeService time;

        // reference to the registry
        private IRegistryService registry;

        // reference to animator component
        private Animator animator;
        


        // MonoBehaviour
        //

        void Awake()
        {
            time = IOC.Resolve<ITimeService>();

            time.TimeUpdated += UpdateTimeText;

            score = IOC.Resolve<IScoreService>();

            score.ScoreUpdated += UpdateScoreText;

            registry = IOC.Resolve<IRegistryService>();

            registry.Register<IGameUI>("GameUI", this);

            animator = GetComponent<Animator>();
        }



        // Animator Events
        //

        /// <summary>
        /// Fire the waveStartAnimationFinished event if there are any subscribers.
        /// </summary>
        public void OnWaveStartAnimationFinished()
        {
            if (waveStartAnimationFinished != null) {
                waveStartAnimationFinished();
            }
        }

        /// <summary>
        /// Fires the waveEndAnimationFinished event if there are any subscribers.
        /// </summary>
        public void OnWaveEndAnimationFinished()
        {
            if (waveEndAnimationFinished != null) {
                waveEndAnimationFinished();
            }
        }

        

        // IGameUI 
        //

        public event AnimationFinishedEvent waveStartAnimationFinished;

        public event AnimationFinishedEvent waveEndAnimationFinished;

        public void SetWaveText(string waveTitle)
        {
            throw new NotImplementedException();
        }

        public void TriggerGameOver()
        {
            animator.SetTrigger("ShowGameOver");
        }

        public void TriggerGameWin()
        {
            animator.SetTrigger("ShowGameWin");
        }

        public void TriggerShowWaveVictory()
        {
            animator.SetTrigger("ShowWaveVictory");
        }

        public void TriggerStartGame()
        {
            animator.SetTrigger("StartGame");
        }

        public void TriggerStartNewWave()
        {
            animator.SetTrigger("StartNewWave");
        }
      


        // Private
        //

        /// <summary>
        /// Update the text that shows the current score.
        /// </summary>
        /// <param name="score">new score value</param>
        void UpdateScoreText(int score)
        {
            scoreText.text = score.ToString().PadLeft(8, '0');
        }

        /// <summary>
        /// Update the text that shows the current time.
        /// </summary>
        /// <param name="time">current time in seconds</param>
        void UpdateTimeText(int time)
        {
            int seconds = time % 60;

            int minutes = (time - seconds) / 60;

            timeText.text = minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        }
    }
}
