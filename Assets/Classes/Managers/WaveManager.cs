// unity
using UnityEngine;
using UnityEngine.SceneManagement;

// game
using SpaceGame.Interfaces;
using System.Collections.Generic;

// vendor
using Fletch;


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
            LostGame,
            WonGame
        }

        [Tooltip("the number of enemies that will be in the current wave")]
        public int enemiesInWave = 0;

        [Tooltip("data about the waves in the game")]
        public WaveData waveData;

        [Tooltip("how long to show wave title")]
        public float showWaveTitleTime = 1.0f;

        [Tooltip("how long to show wave end title")]
        public float showWaveEndTime = 1.0f;

        [Tooltip("how much time to grant as bonus after wave ends")]
        public int bonusTimeAfterWave = 10;
        
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
        private List<IEnemy> enemyList;

        // wave manager current state
        private State state = State.StartingWave;

        // reference to current wave
        private WaveData.Wave currentWave;

        // index of current wave in wavedata array
        private int currentWaveIndex = 0;

        /// <summary>
        /// resolve references to services.
        /// </summary>
        void Awake()
        {
            enemies = IOC.Resolve<IEnemyFactory>();

            time = IOC.Resolve<ITimeService>();
            time.CountdownFinished += OnCountdownFinished;

            registry = IOC.Resolve<IRegistryService>();

            enemyList = new List<IEnemy>();
        }

        /// <summary>
        /// resolve references to actors or ui.
        /// </summary>
        void Start()
        {
            planet = registry.LookUp<IPlanet>("Planet");

            gameUI = registry.LookUp<IGameUI>("GameUI");
            gameUI.waveStartAnimationFinished += OnWaveStartFinished;
            gameUI.waveEndAnimationFinished += OnWaveEndFinished;

            currentWaveIndex = 0;

            currentWave = waveData.waves[0];

            state = State.StartingWave;
        }

        /// <summary>
        /// If the game is in starting wave mode, start a new wave.
        /// If the game is in lose or win mode, allow keyboard exit to main titles.
        /// </summary>
        void Update()
        {
            if (state == State.StartingWave) {
                gameUI.TriggerStartNewWave();
                state = State.WaitingForWaveStartFinish;

            } else if (state == State.LostGame || state == State.WonGame) {
                if (Input.anyKey) {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }

        /// <summary>
        /// When the countdown is finished, trigger a game over.
        /// </summary>
        void OnCountdownFinished()
        {
            time.PauseCountdown();
            gameUI.TriggerGameOver();
            state = State.LostGame;
        }

        /// <summary>
        /// When the wave start animation is finished, initiate the wave, and put 
        /// wave manager into PlayingGame mode.
        /// </summary>
        void OnWaveStartFinished()
        {
            gameUI.TriggerStartGame();

            for (int i = 0; i < currentWave.saucers; ++i) {
                IEnemy enemy = enemies.CreateSaucer();
                Location spawnPoint = planet.GetRandomSpawnPoint();

                enemy.MoveToLocation(spawnPoint);
                enemy.destroyed += OnEnemyDestroyed;

                enemyList.Add(enemy);
            }

            time.SetCountdown(currentWave.time);
            time.StartCountdown();

            state = State.PlayingGame;
        }

        /// <summary>
        /// When the wave end animation is finished, setup the next wave, and put
        /// the wave manager into StaringWave mode.
        /// </summary>
        void OnWaveEndFinished()
        {
            state = State.StartingWave;
        }

        /// <summary>
        /// When enemy dies, remove it from the enemy list. If that list is empty, then
        /// the wave is over. If this was the last wave, then the game was won.
        /// </summary>
        /// <param name="enemy">The enemy that was destroyed</param>
        void OnEnemyDestroyed(IEnemy enemy)
        {
            enemyList.Remove(enemy);

            if (enemyList.Count == 0) {

                currentWaveIndex++;

                time.PauseCountdown();

                if (currentWaveIndex >= waveData.waves.Length) {
                    gameUI.TriggerGameWin();
                    state = State.WonGame;

                } else {
                    time.AddSeconds(bonusTimeAfterWave);
                    currentWave = waveData.waves[currentWaveIndex];
                    gameUI.TriggerShowWaveVictory();
                    state = State.WaitingForWaveEndFinish;
                }
            }
        }

    }
}
