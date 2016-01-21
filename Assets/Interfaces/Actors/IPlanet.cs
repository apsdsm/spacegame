using UnityEngine;

namespace SpaceGame.Interfaces
{
    public interface IPlanet
    {
        /// <summary>
        /// Returns a random position above the surface of the planet.
        /// </summary>
        /// <param name="distanceFromSurface"></param>
        /// <returns>Vector3 random position</returns>
        Vector3 GetRandomPosition ( float distanceFromSurface );
    }
}
