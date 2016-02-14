using UnityEngine;

namespace SpaceGame.Interfaces
{
    public interface IPlanet
    {
        /// <summary>
        /// Returns a random position above the surface of the planet.
        /// </summary>
        /// <param name="distanceFromSurface"></param>
        /// <returns>random spawn point above surface</returns>
        SpawnPoint GetRandomSpawnPoint ( float distanceFromSurface );
    }
}
