// unity
using UnityEngine;
using UnityEngine.UI;

// game
using SpaceGame.Interfaces;
using SpaceGame.Events;

// vendor
using Fletch;
using System;

namespace SpaceGame.UI.Game {
    /// <summary>
    /// Provides the UI for the main game.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class GameUI : MonoBehaviour, IGameUI {

        [Tooltip("The score text element")]
        public Text scoreText;

        [Tooltip("The time text element")]
        public Text timeText;

        [Tooltip("The speed text element")]
        public Text speedText;

        [Tooltip("The wave title text element")]
        public Text waveText;

        // actors
        private IShip ship;

        // services
        private IScoreService score;
        private ITimeService time;
        private IRegistryService registry;

        // components
        private Animator animator;

        // behaviours
        private GameReadyBehaviour gameReadyBehaviour;



        // MonoBehaviour
        //

        void Awake() {
            // time service
            time = IOC.Resolve<ITimeService>();
            time.TimeUpdated += UpdateTimeText;

            // score service
            score = IOC.Resolve<IScoreService>();
            score.ScoreUpdated += UpdateScoreText;

            // registry service
            registry = IOC.Resolve<IRegistryService>();
            registry.Register<IGameUI>("GameUI", this);

            // animator component
            animator = GetComponent<Animator>();

            // game ready behaviour
            gameReadyBehaviour = animator.GetBehaviour<GameReadyBehaviour>();
            gameReadyBehaviour.gameUI = this;
        }

        void Start() {
            ship = registry.LookUp<IShip>("Ship");
            ship.onSpeedChanged += UpdateSpeedtext;
        }



        // IGameUI 
        //

        public event EnterStateEvent onGameReady;

        public void SetWaveText(string waveTitle) {
            waveText.text = waveTitle;
        }

        public void TriggerStartGame() {
            animator.SetTrigger("StartGame");
        }

        public void TriggerGameWin() {
            animator.SetTrigger("ShowGameWin");
        }

        public void TriggerGameOver() {
            animator.SetTrigger("ShowGameOver");
        }

        public void TriggerWaveStartAnimation() {
            animator.SetTrigger("StartNewWave");
        }

        public void TriggerWaveEndAnimation() {
            animator.SetTrigger("ShowWaveEnd");
        }

        public void CallOnGameReady() {
            if (onGameReady != null) {
                onGameReady();
            }
        }



        // Private
        //

        /// <summary>
        /// Update the text that shows the current score.
        /// </summary>
        /// <param name="score">new score value</param>
        void UpdateScoreText(int score) {
            scoreText.text = score.ToString().PadLeft(5, '0');
        }

        /// <summary>
        /// Update the text that shows the current speed.
        /// </summary>
        /// <param name="speed">current speed</param>
        void UpdateSpeedtext(float speed) {
            speedText.text = Mathf.CeilToInt(speed * 10.0f).ToString().PadLeft(5, '0');
        }

        /// <summary>
        /// Update the text that shows the current time.
        /// </summary>
        /// <param name="time">current time in seconds</param>
        void UpdateTimeText(int time) {
            int seconds = time % 60;

            int minutes = (time - seconds) / 60;

            timeText.text = minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        }
    }
}
