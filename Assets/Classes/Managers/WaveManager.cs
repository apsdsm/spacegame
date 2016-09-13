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
            PlayingGame,
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
        private State state = State.PlayingGame;

        // reference to current wave
        private WaveData.Wave currentWave;

        // index of current wave in wavedata array
        private int currentWaveIndex = 0;

        /// <summary>
        /// Set up internal data objects. Resolve references to services.
        /// </summary>
        void Awake()
        {
            // initialize wave info
            currentWaveIndex = 0;

            // get pointer to current wave
            currentWave = waveData.waves[0];

            // create new list to hold enemy references
            enemyList = new List<IEnemy>();

            // resolve services
            enemies = IOC.Resolve<IEnemyFactory>();
            time = IOC.Resolve<ITimeService>();
            registry = IOC.Resolve<IRegistryService>();
        }

        /// <summary>
        /// resolve references to non-service entities.
        /// subscribe to events.
        /// </summary>
        void Start()
        {
            // get registry lookups
            planet = registry.LookUp<IPlanet>("Planet");
            gameUI = registry.LookUp<IGameUI>("GameUI");

            // subscribe to events
            gameUI.onWaveStartAnimationFinished += OnWaveStartAnimationFinished;        
            gameUI.onWaveEndAnimationFinished += OnWaveEndAnimationFinished;
            time.CountdownFinished += OnCountdownFinished;

            // start the game
            CallNewWaveTitles();
        }



        /// <summary>
        /// If the game is in starting wave mode, start a new wave.
        /// If the game is in lose or win mode, allow keyboard exit to main titles.
        /// TODO: remove this logic... put it into a controller class
        /// </summary>
        void Update()
        {
             if (state == State.LostGame || state == State.WonGame) {
                if (Input.anyKey) {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }



        // Event Handlers
        //

        /// <summary>
        /// When the wave start animation is finished, initialize the current wave.
        /// </summary>
        void OnWaveStartAnimationFinished()
        {
            InitWave();
        }
        
        /// <summary>
        /// When the countdown is finished, lose the game.
        /// </summary>
        void OnCountdownFinished()
        {
            LoseGame();
        }

        /// <summary>
        /// When the wave end animation is finished, call the new wave titles.
        /// </summary>
        void OnWaveEndAnimationFinished()
        {
            CallNewWaveTitles();
        }

        /// <summary>
        /// When enemy dies, remove it from the enemy list. If that was the last enemy finish the wave.
        /// </summary>
        /// <param name="enemy">The enemy that was destroyed</param>
        void OnEnemyDestroyed(IEnemy enemy)
        {
            enemyList.Remove(enemy);

            if (IsLastEnemy()) {
                FinishWave();
            }
        }


        //  Private Methods
        //

        /// <summary>
        /// Call the new wave titles. These show information about the current wave.
        /// </summary>
        private void CallNewWaveTitles()
        {
            gameUI.TriggerStartNewWave();
        }

        /// <summary>
        /// Initialize the current wave. Spawn enemies and restart the countdown.
        /// </summary>
        private void InitWave()
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
        }

        /// <summary>
        /// Finish the current wave and prepare to init the next one. If this was 
        /// the last wave, win the game.
        /// </summary>
        private void FinishWave()
        {
            if (IsLastWave()) {
                WinGame();

            } else {
                time.PauseCountdown();

                time.AddSeconds(bonusTimeAfterWave);

                currentWaveIndex++;

                currentWave = waveData.waves[currentWaveIndex];

                gameUI.TriggerShowWaveVictory();
            }
        }
        
        /// <summary>
        /// Win the game.
        /// </summary>
        private void WinGame()
        {
            gameUI.TriggerGameWin();
            state = State.WonGame;
        }

        /// <summary>
        /// Lose the game.
        /// </summary>
        private void LoseGame()
        {
            gameUI.TriggerGameOver();
            state = State.LostGame;
        }

        /// <summary>
        /// Return true if the round is over.
        /// </summary>
        /// <returns></returns>
        private bool IsLastEnemy()
        {
            return enemyList.Count == 0;
        }

        /// <summary>
        /// Return true is game is won.
        /// </summary>
        /// <returns></returns>
        private bool IsLastWave()
        {
            return currentWaveIndex == waveData.waves.Length - 1;
        }
    }
}
