using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceGame.Events;

namespace SpaceGame.Interfaces
{
    public interface IGameUI
    {
        /// <summary>
        /// Set the text used in the wave title
        /// </summary>
        /// <param name="waveTitle">text to show in the title</param>
        void SetWaveText(string waveTitle);

        /// <summary>
        /// switch the new wave trigger.
        /// </summary>
        void TriggerStartNewWave();

        /// <summary>
        /// switch the start game trigger.
        /// </summary>
        void TriggerStartGame();

        /// <summary>
        /// switch the show wave victory trigger.
        /// </summary>
        void TriggerShowWaveVictory();

        /// <summary>
        /// switch the game over trigger.
        /// </summary>
        void TriggerGameOver();
        
        /// <summary>
        /// Fires when the wave start animation finishes
        /// </summary>
        event AnimationFinishedEvent waveStartAnimationFinished;
    }
}
