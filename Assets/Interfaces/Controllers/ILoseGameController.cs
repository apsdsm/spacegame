using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame.Interfaces {

    /// <summary>
    /// A LoseGameController is responsible for picking up on user input after the game
    /// has been lost. It basically just sends the player from the game over screen to
    /// the main menu.
    /// </summary>
    public interface IEndGameController {
 
        /// <summary>
        /// Start collecting input from this controller.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Stop collecting input frmo this controller.
        /// </summary>
        void Connect();
    }
}
