using UnityEngine; 
using SpaceGame.Interfaces;

namespace SpaceGame
{
    /// <summary>
    /// Represents damage to an object
    /// </summary>
    public struct Damage
    {
        // the direction of the damage
        public Vector3 direction;

        // the ammount of damage
        public float ammount;

        // the object that caused the damage
        public IShootable shootable;
    }
}
