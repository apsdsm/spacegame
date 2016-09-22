// unity
using UnityEngine;
using UnityEngine.SceneManagement;

// game
using SpaceGame.Interfaces;
using System.Collections.Generic;

// vendor
using Fletch;


namespace SpaceGame.Actors {
    public class WaveManager : MonoBehaviour {

        [Tooltip("data about the waves in the game")]
        public WaveData waveData;

        // Factories
        private IEnemyFactory enemies;

        // Services
        private ITimeService time;
        private IRegistryService registry;

        // Controllers
        private IShipController shipController;
        private IEndGameController endGameController;

        // Actors 
        private IPlanet planet;

        // UIs
        private IGameUI gameUI;

        // list of enemies that currently exist in the game
        private List<IEnemy> enemyList;

        // reference to current wave
        private WaveData.Wave currentWave;

        // index of current wave in wavedata array
        private int currentWaveIndex = 0;



        // Monobehaviour
        //

        /// <summary>
        /// Set up internal data objects. Resolve references to services.
        /// </summary>
        void Awake() {
            
            // create new list to hold enemy references
            enemyList = new List<IEnemy>();

            // resolve services
            enemies = IOC.Resolve<IEnemyFactory>();
            time = IOC.Resolve<ITimeService>();
            registry = IOC.Resolve<IRegistryService>();
            shipController = IOC.Resolve<IShipController>();
            endGameController = IOC.Resolve<IEndGameController>();

            // initialize wave info
            currentWaveIndex = 0;

            // get pointer to current wave
            currentWave = waveData.waves[0];

            // set start time on countdown
            time.SetCountdown(waveData.startTime);
        }

        /// <summary>
        /// Resolve references to non-service entities.
        /// Subscribe to events.
        /// </summary>
        void Start() {

            // get registry lookups

            planet = registry.LookUp<IPlanet>("Planet");

            gameUI = registry.LookUp<IGameUI>("GameUI");

            // subscribe to events

            time.CountdownFinished += OnCountdownFinished;

            gameUI.onGameReady += OnGameReady;

            // turn on controls

            shipController.Connect();

            // start the first wave

            gameUI.TriggerWaveStartAnimation();
        }



        // Event Handlers
        //

        /// <summary>
        /// When the game state is ready, start the current wave.
        /// </summary>
        void OnGameReady() {
            StartWave();
        }

        /// <summary>
        /// When the countdown is finished, lose the game.
        /// </summary>
        void OnCountdownFinished() {
            LoseGame();
        }

        /// <summary>
        /// When enemy dies, remove it from the enemy list. If that was the last enemy finish the wave.
        /// </summary>
        /// <param name="enemy">The enemy that was destroyed</param>
        void OnEnemyDestroyed(IEnemy enemy) {
            enemyList.Remove(enemy);

            if (IsLastEnemy()) {
                FinishWave();
            }
        }



        //  Private Methods
        //


        /// <summary>
        /// Initialize the current wave. Spawn enemies and restart the countdown.
        /// </summary>
        private void StartWave() {

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
        /// Finish the current wave and prepare to init the next one. If this was the last wave, win the game.
        /// </summary>
        private void FinishWave() {
            if (IsLastWave()) {
                WinGame();

            } else {
                time.PauseCountdown();

                time.AddSeconds(currentWave.time);

                currentWaveIndex++;

                gameUI.SetWaveText("Wave " + (currentWaveIndex + 1).ToString());

                currentWave = waveData.waves[currentWaveIndex];

                gameUI.TriggerWaveEndAnimation();
            }
        }

        /// <summary>
        /// Win the game. Turn over control to the endGameController.
        /// </summary>
        private void WinGame() {
            shipController.Disconnect();

            endGameController.Connect();

            gameUI.TriggerGameWin();
        }

        /// <summary>
        /// Lose the game. Turn over control to the endGameController.
        /// </summary>
        private void LoseGame() {
            shipController.Disconnect();

            endGameController.Connect();

            gameUI.TriggerGameOver();
        }

        /// <summary>
        /// Return true if there are no more enemies.
        /// </summary>
        /// <returns></returns>
        private bool IsLastEnemy() {
            return enemyList.Count == 0;
        }

        /// <summary>
        /// Return true if there are no more waves.
        /// </summary>
        /// <returns></returns>
        private bool IsLastWave() {
            return currentWaveIndex == waveData.waves.Length - 1;
        }
    }
}
