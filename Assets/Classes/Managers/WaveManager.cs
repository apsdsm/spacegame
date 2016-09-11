using UnityEngine;
using UnityEngine.SceneManagement;

using SpaceGame.Interfaces;
using Fletch;
using System.Collections.Generic;

using SpaceGame.Exceptions;

namespace SpaceGame.Actors
{
    public class WaveManager : MonoBehaviour
    {
        // states for the wave manager
        public enum State
        {
            StartingWave,
            WaitingForWaveStartFinish,
            PlayingGame,
            StartingWaveEnd,
            WaitingForWaveEndFinish,
            StartingGameOver
        }

        [Tooltip("the number of enemies that will be in the current wave")]
        public int enemiesInWave = 0;

        [Tooltip("data about the waves in the game")]
        public WaveData waveData;

        [Tooltip("how long to show wave title")]
        public float showWaveTitleTime = 1.0f;

        [Tooltip("how long to show wave end title")]
        public float showWaveEndTime = 1.0f;
        
        // Factories
        private IEnemyFactory enemies;

        // Services
        private ITimeService time;      
        private IRegistryService registry;

        // Actors
        private IPlanet planet;

        // UIs
        private IGameUI gameUI;

        // list of enemies that currently exist in the game
        private List<Saucer> enemyList;

        // wave manager current state
        private State state = State.StartingWave;

        // reference to current wave
        private WaveData.Wave currentWave;

        /// <summary>
        /// resolve references to services.
        /// </summary>
        void Awake()
        {
            enemies = IOC.Resolve<IEnemyFactory>();

            time = IOC.Resolve<ITimeService>();
            time.CountdownFinished += OnCountdownFinished;

            registry = IOC.Resolve<IRegistryService>();

            enemyList = new List<Saucer>();
        }

        /// <summary>
        /// resolve references to other actors. 
        /// TODO: Move this logic to a 'wave start' that is executed after showing wave info.
        /// </summary>
        void Start()
        {
            planet = registry.LookUp<IPlanet>("Planet");

            gameUI = registry.LookUp<IGameUI>("GameUI");
            gameUI.waveStartAnimationFinished += OnWaveStartFinished;

            currentWave = waveData.waves[0];
        }

        void Update()
        {
            if (state == State.StartingWave) {
                OnWaveStart();

            } else if (state == State.PlayingGame) {
                // do nothing

            } else if (state == State.StartingWaveEnd) {
                // do nothing

            } else if (state == State.StartingGameOver) {
                // do nothing

            }
        }

        /// <summary>
        /// When the manager in in init mode it will set the timer, and spawn enemies 
        /// for the current wave.
        /// </summary>
        void OnWaveStart()
        {
            gameUI.TriggerStartNewWave();
            state = State.WaitingForWaveStartFinish;
        }

        /// <summary>
        /// When the countdown is finished, end the game.
        /// For now just kick the player back to the main menu.
        /// </summary>
        void OnCountdownFinished()
        {
            SceneManager.LoadScene("MainMenu");
        }

        /// <summary>
        /// When the wave start animation is finished, do all the wave init actions
        /// and put the wave manager into PlayingGame state.
        /// </summary>
        void OnWaveStartFinished()
        {
            Debug.Log("wave start finished");

            // tell the UI to switch to game mode
            gameUI.TriggerStartGame();

            for (int i = 0; i < currentWave.saucers; ++i) {
                IEnemy enemy = enemies.CreateSaucer();
                Location spawnPoint = planet.GetRandomSpawnPoint();
                enemy.MoveToLocation(spawnPoint);

                enemyList.Add((Saucer)enemy);
            }

            // set and start countdown
            time.SetCountdown(currentWave.time);
            time.StartCountdown();

            state = State.PlayingGame;
        }
    }
}
