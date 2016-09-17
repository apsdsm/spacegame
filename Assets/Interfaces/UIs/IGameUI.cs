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
        /// switch the wave start trigger.
        /// </summary>
        void TriggerWaveStartAnimation();

        /// <summary>
        /// switch the wave victory trigger.
        /// </summary>
        void TriggerWaveEndAnimation();

        /// <summary>
        /// switch the game over trigger.
        /// </summary>
        void TriggerGameOver();

        /// <summary>
        /// switch the game win trigger.
        /// </summary>
        void TriggerGameWin();

        /// <summary>
        /// Fires when the UI finishes showing wave information and is ready to start game actions.
        /// </summary>
        event EnterStateEvent onGameReady;

        /// <summary>
        /// Call the on game ready event. 
        /// </summary>
        void CallOnGameReady();
    }
}
