using UnityEngine;

namespace SpaceGame.Interfaces
{
    /// <summary>
    /// An input service will be responsible for keeping track of user interaction
    /// throughout the lifetime of the program. It will provide methods for other
    /// classes to access that information.
    /// </summary>
    public interface IInputService
    {

        /// <summary>
        /// Returns the current user input for movement as a Vector2.
        /// </summary>
        /// <returns>Vector3 representing user movement</returns>
        Vector2 GetMovement ();


        /// <summary>
        /// Returns true if the current user fired the ship's weapons.
        /// </summary>
        /// <returns>true if weapons were fired</returns>
        bool GetWeaponFired ();
    }
}