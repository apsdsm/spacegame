using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame.Interfaces
{
    interface IShipController
    {
        /// <summary>
        /// register a controllable ship to be the target of this controller
        /// </summary>
        /// <param name="ship">The ship to direct input to</param>
        void Register ( IControllableShip ship );

        /// <summary>
        /// deregister the currently controlled ship if it matches the reference.
        /// </summary>
        void Deregister ( IControllableShip ship );
    }
}
