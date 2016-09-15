using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// A ShipController is responsible for sending input to a registered ship object.
    /// </summary>
    public interface IShipController
    {
        /// <summary>
        /// Stop sending input from this controller to registered objects.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Continue sending input from this controller to registered obejcts.
        /// </summary>
        void Connect();

        /// <summary>
        /// register a controllable ship to be the target of this controller
        /// </summary>
        /// <param name="ship">The ship to direct input to</param>
        void Register(IShip ship);

        /// <summary>
        /// deregister the currently controlled ship if it matches the reference.
        /// </summary>
        void Deregister(IShip ship);
    }
}
